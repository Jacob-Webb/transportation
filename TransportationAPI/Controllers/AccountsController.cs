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
using Microsoft.Extensions.Configuration;
using TransportationAPI.IRepository;

namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TwilioSettings _twilioVerifySettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUnitOfWork _unitOfWork; 

        public AccountsController(IOptions<TwilioSettings> twilioVerifySettings,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger<AccountsController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IUnitOfWork unitOfWork)
        {
            _twilioVerifySettings = twilioVerifySettings.Value;
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
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

            await _userManager.AddToRoleAsync(user, "User");

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

            var validatedPhoneNumber = TwilioSettings.FormatPhoneNumber(userDto.Phone);

            userDto.Phone = validatedPhoneNumber;

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized("The phone number - password combination is invalid. Please try again.");
            }

            // Create AccessToken
            var accessToken = await _authManager.GenerateAccessToken();
            var refreshToken = _authManager.GenerateRefreshToken();
            // Create RefreshToken
            // Set Refresh Token to user
            var user = await _userManager.FindByPhoneAsync(validatedPhoneNumber);

            user.RefreshToken = refreshToken;
            var refreshLifetime = Convert.ToDouble(_configuration.GetSection("Jwt").GetSection("RefreshLifetime").Value);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshLifetime);
            // Save User
            await _userManager.UpdateAsync(user);


            return Accepted(new AuthResponseDto {
                IsAuthSuccessful = true,
                AccessToken = accessToken,
                RefreshToken = user.RefreshToken
            });

        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validatedPhoneNumber = TwilioSettings.FormatPhoneNumber(forgotPasswordDto.Phone);

            var user = await _userManager.FindByPhoneAsync(validatedPhoneNumber);
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            // send out phone verification
            SendPhoneVerification(validatedPhoneNumber);

            return Ok();
        }

        [HttpPost]
        [Route("PhoneVerification")]
        public async Task<IActionResult> PhoneVerification([FromBody] PhoneVerificationDto phoneVerificationDto)
        {
            return await VerifyPhone(phoneVerificationDto);
        }

        [HttpPost]
        [Route("PhoneConfirmation")]
        public async Task<IActionResult> PhoneConfirmation([FromBody] PhoneVerificationDto phoneVerificationDto)
        {
            phoneVerificationDto.PhoneNumber = TwilioSettings.FormatPhoneNumber(phoneVerificationDto.PhoneNumber);
            var verifyResult = await VerifyPhone(phoneVerificationDto);

            if (!verifyResult.Equals(Ok()))
            {
                return verifyResult;
            }

            return await ConfirmPhone(phoneVerificationDto.PhoneNumber);
        }

        private async Task<IActionResult> ConfirmPhone(string phoneNumber)
        {
            var identityUser = await _userManager.FindByPhoneAsync(phoneNumber);

            if (identityUser == null)
            {
                return BadRequest("Invalid client request");
            }

            identityUser.PhoneNumberConfirmed = true;
            var updateResult = await _userManager.UpdateAsync(identityUser);

            if (!updateResult.Succeeded)
            {
                return BadRequest("There was an error confirming the verification code, please try again.");
            }
            return Ok();
        }

        private async Task<IActionResult> VerifyPhone(PhoneVerificationDto phoneVerificationDto)
        {
            if (phoneVerificationDto.PhoneNumber == "undefined")
            {
                return BadRequest($"Value of Phone number is {phoneVerificationDto.PhoneNumber}");
            }

            try
            {
                var verificationCheck = await VerificationCheckResource.CreateAsync(
                 to: phoneVerificationDto.PhoneNumber,
                 code: phoneVerificationDto.Code,
                 pathServiceSid: _twilioVerifySettings.VerificationServiceSID
                );
                if (!(verificationCheck.Status == "approved"))
                {
                    return BadRequest($"There was an error confirming the verification code: {verificationCheck.Status}");
                }
                return Ok();
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
