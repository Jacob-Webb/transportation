using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TransportationAPI.Models;
using TransportationAPI.Extensions;
using TransportationAPI.Middleware;
using TransportationAPI.DTOs;
using TransportationAPI.Services;
using Twilio.Exceptions;
using Twilio.Rest.Lookups.V1;
using System.Collections.Generic;
using Twilio.Rest.Verify.V2.Service;
using System;
using Microsoft.AspNetCore.Authorization;

namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TwilioSettings _twilioVerifySettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountsController(IOptions<TwilioSettings> twilioVerifySettings,
            UserManager<ApplicationUser> userManager,
            ILogger<AccountsController> logger,
            IMapper mapper,
            IAuthManager authManager)
        {
            _twilioVerifySettings = twilioVerifySettings.Value;
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterUserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Phone} ");

            if (userDto == null || !ModelState.IsValid) return BadRequest(ModelState);

            var user = _mapper.Map<ApplicationUser>(userDto);

            string validatedPhoneNumber = null;

            try
            {
                var numberDetails = await PhoneNumberResource.FetchAsync(
                    pathPhoneNumber: new Twilio.Types.PhoneNumber(userDto.Phone),
                    countryCode: "US",
                    type: new List<string> { "carrier" }
                    );
                if (numberDetails?.Carrier != null
                    && numberDetails.Carrier.TryGetValue("type", out var phoneNumberType)
                    && phoneNumberType == "landline")
                {
                    return StatusCode(406,
                        $"The number you entered does not appear to be capable of receiving SMS ({phoneNumberType}). Please enter a different number and try again");
                }

                validatedPhoneNumber = numberDetails.PhoneNumber.ToString();
            }
            catch (ApiException ex)
            {
                return StatusCode(406, $"The number you entered was not valid (Twilio code {ex.Code}), please check it and try again");
            }


            // Check if phone number is already used and confirmed
            var existingPhoneUser = await _userManager.FindByPhoneAsync(validatedPhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.PhoneNumberConfirmed)
            {
                return Conflict("Phone number already in use. Please contact The Rock's Transportation Department.");
            }
            if (existingPhoneUser != null && !existingPhoneUser.PhoneNumberConfirmed)
            {
                // resend confirmation phone number and code to frontend to activate phone number then return
                SendPhoneVerification(validatedPhoneNumber);
                return StatusCode(403, "This number needs to be confirmed. Please enter your verification code to complete registration.");
            }

            user.UserName = userDto.FirstName.Substring(0, 1) + userDto.LastName + validatedPhoneNumber.Substring(8, 4);
            user.PhoneNumber = validatedPhoneNumber;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRoleAsync(user, userDto.Role);

            SendPhoneVerification(user.PhoneNumber);
            return Ok(userDto.Phone);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Phone} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validatedNumber = TwilioSettings.FormatPhoneNumber(userDto.Phone);

            userDto.Phone = validatedNumber;

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized("The phone number - password combination is invalid. Please try again.");
            }

            // Create AccessToken
            var accessToken = await _authManager.GenerateAccessToken();
            var refreshToken = _authManager.GenerateRefreshToken();
            // Create RefreshToken
            // Set Refresh Token to user
            var user = await _userManager.FindByPhoneAsync(userDto.Phone);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            // Save User

            return Accepted(new AuthResponseDto {
                IsAuthSuccessful = true,
                AccessToken = await _authManager.GenerateAccessToken(),
                RefreshToken = _authManager.GenerateRefreshToken()
            });

        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> RefreshToken(TokenDto tokenDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tokenDto == null)
            {
                return BadRequest("Invalid client request");
            }

            string accessToken = tokenDto.AccessToken;
            string refreshToken = tokenDto.RefreshToken;

            var principal = _authManager.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }

            var newAccessToken = await _authManager.GenerateAccessToken();
            var newRefreshToken = _authManager.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            var updatedUser = await _userManager.UpdateAsync(user);

            return Accepted(new TokenDto { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
        }

        [HttpPost]
        [Authorize]
        [Route("Revoke")]
        public async Task<IActionResult> RevokeToken()
        {
            var username = User.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null) return BadRequest();

            user.RefreshToken = null;

            var updatedUser = await _userManager.UpdateAsync(user);
            return NoContent();
        }

        [HttpPost]
        [Route("PhoneVerification/{phone}")]
        public async Task<IActionResult> PhoneVerification(string phone, [FromBody] PhoneVerificationDto verification)
        {

            if (phone == "undefined")
            {
                return StatusCode(403, $"Value of Phone number is {phone}");
            }

            var validPhone = TwilioSettings.FormatPhoneNumber(phone);
            try
            {
                var verificationCheck = await VerificationCheckResource.CreateAsync(
                 to: validPhone,
                 code: verification.Code,
                 pathServiceSid: _twilioVerifySettings.VerificationServiceSID
                );
                if (verificationCheck.Status == "approved")
                {
                    var identityUser = await _userManager.FindByPhoneAsync(validPhone);
                    identityUser.PhoneNumberConfirmed = true;
                    var updateResult = await _userManager.UpdateAsync(identityUser);

                    if (updateResult.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return StatusCode(403, "There was an error confirming the verification code, please try again");
                    }
                }
                else
                {
                    return StatusCode(403, $"There was an error confirming the verification code: {verificationCheck.Status}");
                }
            }
            catch (TwilioException ex)
            {
                return StatusCode(500, new List<string> { ex.Message });
            }
        }

        private async void SendPhoneVerification(string phone)
        {
            var verification = await VerificationResource.CreateAsync(
                to: phone,
                channel: "sms",
                pathServiceSid: _twilioVerifySettings.VerificationServiceSID
            );

            if (verification.Status != "pending")
            {
                ModelState.AddModelError("", $"There was an error sending the verification code: {verification.Status}");
            }
        }
    }
}
