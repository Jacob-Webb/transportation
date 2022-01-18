using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateWeeklyGatheringsFromTemplates> _logger;

       /// <summary>
        /// Initializes a new instance of the <see cref="CreateWeeklyGatheringsFromTemplates"/> class.
        /// </summary>
        /// <param name="unitOfWork">An instance of <see cref="ApplicationDbContext"/>.</param>
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

            var daysInAWeek = 7;

            var gatheringsFromTemplates = GetGatheringsFromTemplates(_unitOfWork.GatheringTemplates.GetAll(template => template.Active), daysInAWeek)
                .OrderBy(gathering => gathering.DateAndTime)
                .ToList();

            var savedGatherings = GetGatheringsFromStorage(DateTime.Now, DateTime.Now.AddDays(daysInAWeek))
                .OrderBy(gathering => gathering.DateAndTime)
                .ToList();

            // Walk through the sorted lists, removing a template from the list if it matches an existing Gathering
            RemoveExistingGatherings(savedGatherings, gatheringsFromTemplates);

            foreach (var newGathering in gatheringsFromTemplates)
            {
                _unitOfWork.Gatherings.Insert(newGathering);
                _unitOfWork.Save();
            }
        }

        private IList<Gathering> GetGatheringsFromStorage(DateTime now, DateTime endDate)
        {
            return _unitOfWork.Gatherings.GetAll(gathering =>
                gathering.DateAndTime.CompareTo(now) >= 0 && gathering.DateAndTime.CompareTo(endDate) <= 0);
        }

        private IList<Gathering> GetGatheringsFromTemplates(IList<GatheringTemplate> activeTemplates, int daysInAWeek)
        {
            var gatheringList = new List<Gathering>();
            foreach (var template in activeTemplates)
            {
                var templatesDayOfTheWeek = (int)template.DayOfWeek;
                var currentDayOfTheWeek = (int)DateTime.Now.DayOfWeek;
                int occursFollowingWeek = 0;

                if (currentDayOfTheWeek >= templatesDayOfTheWeek)
                {
                    occursFollowingWeek = 1;
                }

                var fromNowUntilTemplatsDayOfTheWeek = templatesDayOfTheWeek - currentDayOfTheWeek + (occursFollowingWeek * daysInAWeek);
                var newGatheringDateTime = DateTime.Now.AddDays(fromNowUntilTemplatsDayOfTheWeek);
                var newGathering = new Gathering
                {
                    DateAndTime = new DateTime(
                        newGatheringDateTime.Year,
                        newGatheringDateTime.Month,
                        newGatheringDateTime.Day,
                        template.TimeOfDay.Hours,
                        template.TimeOfDay.Minutes,
                        0),
                };

                gatheringList.Add(newGathering);
            }

            return gatheringList;
        }

        private void RemoveExistingGatherings(List<Gathering> savedGatherings, List<Gathering> gatheringsFromTemplates)
        {
            var templateIndex = 0;
            var storageIndex = 0;
            var templateCount = gatheringsFromTemplates.Count;

            while (templateIndex < templateCount && storageIndex < savedGatherings.Count)
            {
                if (gatheringsFromTemplates[templateIndex].DateAndTime < savedGatherings[storageIndex].DateAndTime)
                {
                    ++templateIndex;
                }
                else if (gatheringsFromTemplates[templateIndex].DateAndTime > savedGatherings[storageIndex].DateAndTime)
                {
                    ++storageIndex;
                }
                else if (gatheringsFromTemplates[templateIndex].DateAndTime == savedGatherings[storageIndex].DateAndTime)
                {
                    gatheringsFromTemplates.RemoveAt(templateIndex);
                    --templateCount;
                }
            }
        }
    }
}
