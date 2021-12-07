using System;
using System.Security.Claims;
using System.Threading.Tasks;
using TransportationAPI.DTOs;

namespace TransportationAPI.Services
{
    public interface IAuthManager
    {
        Task<string> GenerateAccessToken();
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<bool> ValidateUser(LoginUserDto userDto);
    }
}
