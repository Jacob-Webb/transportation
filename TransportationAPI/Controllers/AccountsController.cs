using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.Extensions;
using TransportationAPI.Helpers;
using TransportationAPI.Middleware;
using TransportationAPI.Models;
using TransportationAPI.Services;
using Twilio.Exceptions;
using Twilio.Rest.Verify.V2.Service;

namespace TransportationAPI.Controllers
{
    /// <summary>
    /// Class <c>AccountsController</c> allows API calls relating to an ApplicationUsers account information.
    /// </summary>
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

        public AccountsController(
            IOptions<TwilioSettings> twilioVerifySettings,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger<AccountsController> logger,
            IMapper mapper,
            IAuthManager authManager)
        {
            _twilioVerifySettings = twilioVerifySettings.Value;
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
        }

        /// <summary>
        /// Validates user input, including phone number, ensures that the user does not already exist, then creates the user in the database.
        /// </summary>
        /// <param name="userDto">
        /// The <see cref="RegisterUserDto"/> instance that represents the information passed to and from the frontend
        /// for user registration.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Ok code and return the user's phone number, which is their identifier,
        /// as a <see cref="PhoneNumberDto"/>.
        /// Errors return appropriate status codes and informative error messagses.
        /// </returns>
        [HttpPost]
        [Route("Registration")]
        public async Task<IActionResult> Registration([FromBody] RegisterUserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.PhoneNumber} ");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<ApplicationUser>(userDto);

            var formatStatus = await TwilioSettings.FormatPhoneNumberAsync(userDto.PhoneNumber);

            var statusCode = (int)formatStatus.Code;
            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatStatus.Response);
            }

            string validatedPhoneNumber = formatStatus.Response;

            // Check if phone number is already used and confirmed.
            var existingPhoneUser = await _userManager.FindByPhoneAsync(validatedPhoneNumber);
            if (existingPhoneUser != null && existingPhoneUser.PhoneNumberConfirmed)
            {
                return Conflict("This phone number is already in use. Please contact The Rock's Transportation Department.");
            }

            if (existingPhoneUser != null && !existingPhoneUser.PhoneNumberConfirmed)
            {
                // Resend confirmation phone number and code to frontend to activate phone number then return.
                await SendPhoneVerification(validatedPhoneNumber);
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

            await SendPhoneVerification(user.PhoneNumber);
            return Ok(new PhoneNumberDto { PhoneNumber = userDto.PhoneNumber });
        }

        /// <summary>
        /// Retrieves user based on validated phone number, creates an access token and refresh token,
        /// assigns tokens, and updates the user.
        /// </summary>
        /// <param name="userDto">
        /// The <see cref="AuthenticationDto"/> instance that represents the information passed to and from the frontend
        /// for user authentication.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Accepted code and an instance of <see cref="AuthResponseDto"/>.
        ///  Errors return appropriate status codes and informative error messagses.
        /// </returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticationDto userDto)
        {
            _logger.LogInformation($"Login attempt for {userDto.PhoneNumber} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formatResult = await TwilioSettings.FormatPhoneNumberAsync(userDto.PhoneNumber);
            var statusCode = (int)formatResult.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatResult.Response);
            }

            var validatedPhoneNumber = formatResult.Response;

            userDto.PhoneNumber = validatedPhoneNumber;

            if (!await _authManager.ValidateUserAsync(userDto))
            {
                return Unauthorized("The phone number - password combination is invalid. Please try again.");
            }

            // Create AccessToken
            var accessToken = await _authManager.GenerateAccessTokenAsync();
            var refreshToken = _authManager.GenerateRefreshToken();

            // Create RefreshToken
            // Set Refresh Token to user
            var user = await _userManager.FindByPhoneAsync(validatedPhoneNumber);

            user.RefreshToken = refreshToken;
            var refreshLifetime = Convert.ToDouble(_configuration.GetSection("Jwt").GetSection("RefreshLifetime").Value);
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshLifetime);

            // Save User
            await _userManager.UpdateAsync(user);

            return Accepted(new AuthResponseDto
            {
                IsAuthSuccessful = true,
                AccessToken = accessToken,
                RefreshToken = user.RefreshToken,
            });
        }

        /// <summary>
        /// Updates a user's PhoneNumberConfirmed field to `true` upon successful phone verification.
        /// </summary>
        /// <param name="phoneVerificationDto">
        /// The <see cref="PhoneVerificationDto"/> instance that represents the information passed to and from the frontend
        /// for phone verification.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Ok status code.
        /// Errors return appropriate status codes and informative error messages.
        /// </returns>
        [HttpPost]
        [Route("PhoneConfirmation")]
        public async Task<IActionResult> PhoneConfirmation([FromBody] PhoneVerificationDto phoneVerificationDto)
        {
            var formatResult = await TwilioSettings.FormatPhoneNumberAsync(phoneVerificationDto.PhoneNumber);
            var statusCode = (int)formatResult.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatResult.Response);
            }

            phoneVerificationDto.PhoneNumber = formatResult.Response;

            var verificationStatus = await VerifyPhone(phoneVerificationDto);
            statusCode = (int)verificationStatus.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, verificationStatus.Response);
            }

            var confirmationStatus = await ConfirmPhone(phoneVerificationDto.PhoneNumber);

            return StatusCode((int)confirmationStatus.Code);
        }

        /// <summary>
        /// Generates a password reset token for the user, if any, found by the valid phone number.
        /// </summary>
        /// <param name="phoneNumberDto">
        /// The <see cref="PhoneNumberDto"/> instance that represents the information passed to and from the frontend
        /// to reset a password prior to user authentication.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Ok status code.
        /// Errors return appropriate status codes and informative error messages.
        /// </returns>
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(PhoneNumberDto phoneNumberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formatResult = await TwilioSettings.FormatPhoneNumberAsync(phoneNumberDto.PhoneNumber);
            var statusCode = (int)formatResult.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatResult.Response);
            }

            var validatedPhoneNumber = formatResult.Response;

            var user = await _userManager.FindByPhoneAsync(validatedPhoneNumber);
            if (user == null || !user.PhoneNumberConfirmed)
            {
                return BadRequest("Invalid client request");
            }

            // send out phone verification
            await SendPhoneVerification(validatedPhoneNumber);

            return Ok();
        }

        /// <summary>
        /// Finds user by  valid phone number and resets password.
        /// </summary>
        /// <param name="resetPasswordDto">
        /// The <see cref="ResetPasswordDto"/> instance that represents the information passed to and from the frontend
        /// to reset a password.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Ok status.
        /// Errors return appropriate status codes and informative error messages.
        /// </returns>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formatResult = await TwilioSettings.FormatPhoneNumberAsync(resetPasswordDto.PhoneNumber);
            var statusCode = (int)formatResult.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatResult.Response);
            }

            var validatedPhoneNumber = formatResult.Response;

            var user = await _userManager.FindByPhoneAsync(validatedPhoneNumber);
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var updateResult = await _userManager.ResetPasswordAsync(
                user,
                await _userManager.GeneratePasswordResetTokenAsync(user),
                resetPasswordDto.Password);

            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return Ok();
        }

        /// <summary>
        /// Verify a code-phone number pair then generate a password reset token for the user identified by the phone number.
        /// </summary>
        /// <param name="phoneVerificationDto">
        /// The <see cref="PhoneVerificationDto"/> instance that represents the information passed to and from the frontend
        /// for phone verification.
        /// </param>
        /// <returns>
        /// An instance of <see cref="IActionResult"/> class representing the status code and content.
        /// A successful operation should return an Accepted code and an instance of <see cref="ResetPasswordDto"/>.
        /// Errors return appropriate status codes and informative error messagses.
        /// </returns>
        [HttpPost]
        [Route("ResetPasswordToken")]
        public async Task<IActionResult> ResetPasswordToken([FromBody] PhoneVerificationDto phoneVerificationDto)
        {
            var formatResult = await TwilioSettings.FormatPhoneNumberAsync(phoneVerificationDto.PhoneNumber);
            var statusCode = (int)formatResult.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, formatResult.Response);
            }

            phoneVerificationDto.PhoneNumber = formatResult.Response;

            HttpStatus verificationStatus = await VerifyPhone(phoneVerificationDto);
            statusCode = (int)verificationStatus.Code;

            if (statusCode < 200 || statusCode >= 300)
            {
                return StatusCode(statusCode, verificationStatus.Response);
            }

            var user = await _userManager.FindByPhoneAsync(phoneVerificationDto.PhoneNumber);

            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var response = new ResetPasswordDto
            {
                Password = null,
                PhoneNumber = phoneVerificationDto.PhoneNumber,
                Token = token,
            };

            return Accepted(response);
        }

        private async Task<HttpStatus> ConfirmPhone(string phoneNumber)
        {
            var identityUser = await _userManager.FindByPhoneAsync(phoneNumber);

            if (identityUser == null)
            {
                return new HttpStatus
                {
                    Code = HttpStatusCode.BadRequest,
                    Response = "Bad client request",
                };
            }

            identityUser.PhoneNumberConfirmed = true;
            var updateResult = await _userManager.UpdateAsync(identityUser);

            if (!updateResult.Succeeded)
            {
                return new HttpStatus
                {
                    Code = HttpStatusCode.BadRequest,
                    Response = "There was an error confirming the verification code, please try again.",
                };
            }

            return new HttpStatus
            {
                Code = HttpStatusCode.OK,
                Response = null,
            };
        }

        private async Task<HttpStatus> VerifyPhone(PhoneVerificationDto phoneVerificationDto)
        {
            if (phoneVerificationDto.PhoneNumber == "undefined")
            {
                return new HttpStatus
                {
                    Code = HttpStatusCode.BadRequest,
                    Response = $"Value of Phone number is {phoneVerificationDto.PhoneNumber}",
                };
            }

            try
            {
                var verificationCheck = await VerificationCheckResource.CreateAsync(
                 to: phoneVerificationDto.PhoneNumber,
                 code: phoneVerificationDto.Code,
                 pathServiceSid: _twilioVerifySettings.VerificationServiceSID);
                if (verificationCheck.Status != "approved")
                {
                    return new HttpStatus
                    {
                        Code = HttpStatusCode.BadRequest,
                        Response = $"There was an error confirming the verification code. Please check your code and try again.",
                    };
                }

                return new HttpStatus
                {
                    Code = HttpStatusCode.Accepted,
                    Response = string.Empty,
                };
            }
            catch (TwilioException ex)
            {
                return new HttpStatus
                {
                    Code = HttpStatusCode.InternalServerError,
                    Response = ex.Message,
                };
            }
        }

        private async Task SendPhoneVerification(string phone)
        {
            var verification = await VerificationResource.CreateAsync(
                to: phone,
                channel: "sms",
                pathServiceSid: _twilioVerifySettings.VerificationServiceSID);

            if (verification.Status != "pending")
            {
                ModelState.AddModelError(string.Empty, $"There was an error sending the verification code: {verification.Status}");
            }
        }
    }
}
