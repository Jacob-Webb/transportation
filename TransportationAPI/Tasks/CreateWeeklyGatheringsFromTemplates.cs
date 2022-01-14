using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Linq;
using System.Threading.Tasks;
using TransportationAPI.Controllers;
using TransportationAPI.IRepository;
using TransportationAPI.Models;

namespace TransportationAPI.Tasks
{
    /// <summary>
    /// Contains Tasks to create Weekly Gatherings from all active GatheringTemplates.
    /// </summary>
    [DisallowConcurrentExecution]
    public class CreateWeeklyGatheringsFromTemplates : IJob
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GatheringsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWeeklyGatheringsFromTemplates"/> class.
        /// </summary>
        /// <param name="context">An instance of <see cref="ApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/>.</param>
        public CreateWeeklyGatheringsFromTemplates(
            ApplicationDbContext context,
            ILogger<GatheringsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Executes the task as a cron job at scheduled intervals.
        /// </summary>
        /// <param name="context">An instance of <see cref="IJobExecutionContext"/>, which handles to various
        /// environment information, that is given to a <see cref="IJobDetail"/> instance as it is executed,
        /// and to a <see cref="ITrigger"/> instance after the execution completes.
        /// For more information, see <see href="https://quartznet.sourceforge.io/apidoc/3.0/html/html/52632202-34fc-72ad-56c3-5e6d34ab16fe.htm"/>.</param>
        /// <returns>An instance of <see cref="Task"/>.</returns>
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Execute();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// For each active <see cref="GatheringTemplate"/>, a new <see cref="Gathering"/> is created with a <see cref="DateTime"/> of the
        /// upcoming <see cref="DayOfWeek"/> and <see cref="TimeOfDay"/> from the active template.
        /// Leave all other properties null.
        /// </summary>
        /// <remarks>
        /// This method should be used to execute the task whenever it needs to be done manually.
        /// </remarks>
        public void Execute()
        {
            _logger.LogInformation("Creating weekly gatherings.");

            foreach (var activeTemplate in _context.GatheringTemplates.Where(template => template.Active))
            {
                _logger.LogInformation(activeTemplate.Id.ToString());
            }
        }
    }
}
