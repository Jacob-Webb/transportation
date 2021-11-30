using System;
using System.Threading.Tasks;
using TransportationAPI.DTOs;

namespace TransportationAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(UserLoginDto userDto);
        Task<string> CreateToken();
    }
}
