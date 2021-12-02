using System;
using System.Threading.Tasks;
using TransportationAPI.DTOs;

namespace TransportationAPI.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDto userDto);
        Task<string> CreateToken();
    }
}
