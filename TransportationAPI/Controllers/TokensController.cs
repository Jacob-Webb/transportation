using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.IRepository;
using TransportationAPI.Models;
using TransportationAPI.Services;

namespace TransportationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUnitOfWork _unitOfWork;

        public TokensController(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            ILogger<AccountsController> logger,
            IMapper mapper,
            IAuthManager authManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> Refresh(TokenDto tokenDto)
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
            var username = principal.Identity.Name; // this is mapped to the Name claim by default

            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.RefreshToken != refreshToken)
            {
                return BadRequest("Invalid client request");
            }

            if (user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return StatusCode(403, "Session timed out. Please login again");
            }

            var newAccessToken = await _authManager.GenerateAccessToken(user);
            var newRefreshToken = _authManager.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;

            await _userManager.UpdateAsync(user);

            return Accepted(new TokenDto { AccessToken = newAccessToken, RefreshToken = newRefreshToken });
        }

        [HttpPost]
        [Authorize]
        [Route("Revoke")]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return BadRequest();
            }

            user.RefreshToken = null;

            await _userManager.UpdateAsync(user);
            return NoContent();
        }
    }
}
