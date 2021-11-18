using System;
using System.Threading.Tasks;

namespace TransportationAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDto userDto);
        Task<string> CreateToken();
    }
}
