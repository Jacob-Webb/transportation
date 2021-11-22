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
            try
            {
                _logger.LogInformation("Removing unverified accounts");
                _context.Users.Where(u => u.PhoneNumberConfirmed == false).DeleteFromQuery();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
            }
            return Task.CompletedTask;
        }
    }
}
