using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using TransportationAPI.Data;
using TransportationAPI.Extensions;
using TransportationAPI.Middleware;
using TransportationAPI.Models;
using TransportationAPI.Services;
using Twilio.Exceptions;
using Twilio.Rest.Lookups.V1;
using System.Collections.Generic;
using Twilio.Rest.Verify.V2.Service;
namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly TwilioVerifySettings _twilioVerifySettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;

        public AccountsController(IOptions<TwilioVerifySettings> twilioVerifySettings,
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
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
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
                return Conflict("Phone number already in use.");
            }
            if (existingPhoneUser != null && !existingPhoneUser.PhoneNumberConfirmed)
            {
                // resend confirmation phone number and code to frontend to activate phone number then return
                return StatusCode(403, "This number needs to be confirmed. Please see the text sent to you.");
            }

            user.UserName = userDto.FirstName.Substring(0, 1) + userDto.LastName + validatedPhoneNumber.Substring(8, 4);
            user.PhoneNumber = validatedPhoneNumber;
            SendPhoneVerification(user.PhoneNumber);
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

            return Ok();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.Phone} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _authManager.ValidateUser(userDto))
            {
                return Unauthorized();
            }

            return Accepted(new { Token = await _authManager.CreateToken() });

        }

        [HttpPost]
        [Route("PhoneConfirmed")]
        public async Task<IActionResult> PhoneConfirmed(string userPhone, string verificationCode)
        {
            var validPhone = GetFormattedPhone(userPhone);
            try
            {
                var verification = await VerificationCheckResource.CreateAsync(
                    to: userPhone,
                    code: verificationCode,
                    pathServiceSid: _twilioVerifySettings.VerificationServiceSID
                );
                if (verification.Status == "approved")
                {
                    var identityUser = await _userManager.FindByPhoneAsync(userPhone);
                    identityUser.PhoneNumberConfirmed = true;
                    var updateResult = await _userManager.UpdateAsync(identityUser);

                    if (updateResult.Succeeded)
                    {
                        return Ok("ConfirmPhoneSuccess");
                    }
                    else
                    {
                        return StatusCode(403, "There was an error confirming the verification code, please try again");
                    }
                }
                else
                {
                    return StatusCode(403, $"There was an error confirming the verification code: {verification.Status}");
                }
            }
            catch (ApiException ex)
            {
                return StatusCode(403,
                    "There was an error confirming the code, please check the verification code is correct and try again");
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
        private static async Task<string> GetFormattedPhone(string phone)
        {
            var type = new List<string> {
                "carrier"
            };

            var formattedPhoneNumber = await PhoneNumberResource.FetchAsync(
                type: type,
                pathPhoneNumber: new Twilio.Types.PhoneNumber(phone)
            );

            return formattedPhoneNumber.PhoneNumber.ToString();
        }
    }
}
