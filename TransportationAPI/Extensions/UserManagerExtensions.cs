

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TransportationAPI.Models;

namespace TransportationAPI.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByPhoneAsync(this UserManager<ApplicationUser> userManager, string phoneNumber)
        {
            return await userManager?.Users?.SingleOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
        }
    }
}
