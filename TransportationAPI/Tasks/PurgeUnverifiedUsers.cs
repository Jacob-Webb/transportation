using System;
using Quartz;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TransportationAPI.Tasks
{
    [DisallowConcurrentExecution]
    public class PurgeUnverifiedUsersJob : IJob
    {
        private readonly ILogger<PurgeUnverifiedUsersJob> _logger;
        public PurgeUnverifiedUsersJob(ILogger<PurgeUnverifiedUsersJob> logger)
        {
            
        }

        public Task Execute(IJobExecutionContext context)
        {
            
            return Task.CompletedTask;
        }
    }
}
