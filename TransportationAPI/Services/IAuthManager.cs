using System.Security.Claims;
using System.Threading.Tasks;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPI.Services
{
    /// <summary>
    /// IAuthManager interface is implemented by an auth manager application component.
    /// </summary>
    /// <remarks>
    /// An auth manager is mainly responsible for providing role-based access control(RBAC) service.
    /// </remarks>
    public interface IAuthManager
    {
        /// <summary>
        /// Generate an authentication token allowing access to a user for a short time.
        /// </summary>
        /// <param name="user">An instance of type <see cref="ApplicationUser"/>.</param>
        /// <returns>An instance of type <see cref="Task{TResult}"/>.</returns>
        Task<string> GenerateAccessToken(ApplicationUser user = null);

        /// <summary>
        /// Generate a long-term token to allow a user's access token to be refreshed as long as it is viable.
        /// </summary>
        /// <returns>An instance of type <see cref="string"/>.</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Gets an instance of <see cref="ClaimsPrincipal"/> from a token.
        /// </summary>
        /// <param name="token">A <see cref="string"/> representing a token.</param>
        /// <returns>An instance of type <see cref="ClaimsPrincipal"/>.</returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        /// <summary>
        /// Find user by instance of <see cref="AuthenticationDto"/> and check that the passwords match.
        /// </summary>
        /// <param name="userDto">An instance of <see cref="AuthenticationDto"/>.</param>
        /// <returns>An instance of type <see cref="Task{TResult}"/>.</returns>
        Task<bool> ValidateUser(AuthenticationDto userDto);
    }
}
