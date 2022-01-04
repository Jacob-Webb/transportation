using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransportationAPI.Models;

namespace TransportationAPI.Tasks
{
    [DisallowConcurrentExecution]
    public class PurgeUnverifiedUsers : IJob
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PurgeUnverifiedUsers> _logger;

        public PurgeUnverifiedUsers(ApplicationDbContext context, ILogger<PurgeUnverifiedUsers> logger)
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
