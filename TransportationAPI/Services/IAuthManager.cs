using System.Security.Claims;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPI.Services
{
    public interface IAuthManager
    {
        Task<string> GenerateAccessToken(ApplicationUser user = null);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<bool> ValidateUser(AuthenticationDto userDto);
    }
}
