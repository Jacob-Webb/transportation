using System;
using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using TransportationAPI.Data;
using System.Linq;

namespace TransportationAPI.Tasks
{
    [DisallowConcurrentExecution]
    public class PurgeUnverifiedUsersJob : IJob
    {
        private readonly TransportationContext _context;
        private readonly ILogger<PurgeUnverifiedUsersJob> _logger;

        public PurgeUnverifiedUsersJob(TransportationContext context, ILogger<PurgeUnverifiedUsersJob> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Scheduled removal of unconfirmed users attempted");
            _context.Users.Where(u => u.PhoneNumberConfirmed == false).DeleteFromQueryAsync();
            //public static async Task<ApplicationUser> FindByPhoneAsync(this UserManager<ApplicationUser> userManager, string phoneNumber)
            //{
            //    return await userManager?.Users?.SingleOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
            //}
            return Task.CompletedTask;
        }
    }
}
