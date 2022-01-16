using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateWeeklyGatheringsFromTemplates> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateWeeklyGatheringsFromTemplates"/> class.
        /// </summary>
        /// <param name="context">An instance of <see cref="ApplicationDbContext"/>.</param>
        /// <param name="logger">An instance of <see cref="ILogger{TCategoryName}"/>.</param>
        public CreateWeeklyGatheringsFromTemplates(
            IUnitOfWork unitOfWork,
            ILogger<CreateWeeklyGatheringsFromTemplates> logger)
        {
            _unitOfWork = unitOfWork;
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

            /*
             * Get all of the gatherings for the next week. 
             * For each active template, check if a gathering already exists with the DayOfWeek and TimeOfDay. 
             * If none exists, create the gathering with that information. 
             */

            var now = DateTime.Now;

            // Get all gatherings between now and nextweek
            var thisWeeksGatherings = ThisWeeksGatherings(now);

            //if (thisWeeksGatherings != null)
            //{
            //    var activeTemplates = from templates in _unitOfWork.GatheringTemplates.GetAll()
            //                          from gatherings in thisWeeksGatherings
            //                          where templates.Active
            //                            && (templates.DayOfWeek != gatherings.GatheringDateTime.DayOfWeek)
            //                            && (templates.TimeOfDay != gatherings.GatheringDateTime.TimeOfDay)
            //                          select templates;
            //}

            var activeTemplates = _unitOfWork.GatheringTemplates.GetAll(template => template.Active);
            foreach (var activeTemplate in activeTemplates)
            {
                foreach (var gathering in thisWeeksGatherings)
                {
                    if ((activeTemplate.DayOfWeek == gathering.DateAndTime.DayOfWeek) && (activeTemplate.TimeOfDay == gathering.DateAndTime.TimeOfDay))
                    {
                        activeTemplates.Remove(activeTemplate);
                    }
                }
            }

            foreach (var templateWithoutGathering in activeTemplates)
            {
                var gathering = now;
                var dayDifference = (int)templateWithoutGathering.DayOfWeek - (int)now.DayOfWeek;
                if (dayDifference <= 0)
                {
                    dayDifference += 7;
                }

                var gatheringDay = gathering.AddDays(dayDifference);
                _unitOfWork.Gatherings.Insert(new Gathering
                {
                    DateAndTime = new DateTime(now.Year, now.Month, gatheringDay.Day, templateWithoutGathering.TimeOfDay.Hours, templateWithoutGathering.TimeOfDay.Minutes, 0),
                });
            }
        }

        private IList<Gathering> ThisWeeksGatherings(DateTime now)
        {
            var nextWeek = now.AddDays(7);

            return _unitOfWork.Gatherings.GetAll(gathering =>
                gathering.DateAndTime.CompareTo(now) >= 0 && gathering.DateAndTime.CompareTo(nextWeek) <= 0);
        }
    }
}
