using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Quartz;
using TransportationAPI.Models;
using TransportationAPI.Tasks;

namespace TransportationAPITests.Tasks
{
    [TestFixture]
    public class CreateWeeklyGatheringsFromTemplatesTest
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private ApplicationDbContext _context;
        private  Mock<ILogger<CreateWeeklyGatheringsFromTemplates>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TemplatesDatabase")
                .Options;

            _context = new ApplicationDbContext(_options);
            Seed(_context);

            _mockLogger = new Mock<ILogger<CreateWeeklyGatheringsFromTemplates>>();
        }

        [Test]
        public void Execute_UpcomingActiveTemplates_CreateOrUpdateWeeklyGatherings()
        {
            // Assign
            var job = new CreateWeeklyGatheringsFromTemplates(_context, _mockLogger.Object);
            var mockIJobExecutionContext = new Mock<IJobExecutionContext>();

            // Act
            job.Execute(mockIJobExecutionContext.Object);

            List<Gathering> result = _context.Gatherings.ToList();

            // Assert
            mockIJobExecutionContext.VerifyAll();
            Assert.That(result, Is.TypeOf<List<Gathering>>());
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].GatheringDateTime.DayOfWeek, Is.EqualTo(System.DayOfWeek.Sunday));
        }

        /// <summary>
        /// Initialize the context with a few GatheringTemplates.
        /// </summary>
        /// <param name="context">Instance of <see cref="DbContext"/>.</param>
        private void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var templateOne = new GatheringTemplate
            {
                Id = 1,
                DayOfWeek = System.DayOfWeek.Sunday,
                TimeOfDay = new System.TimeSpan(9, 0, 0),
                Language = "English",
                DriversNeeded = 3,
                Active = true,
            };

            var templateTwo = new GatheringTemplate
            {
                Id = 2,
                DayOfWeek = System.DayOfWeek.Wednesday,
                TimeOfDay = new System.TimeSpan(19, 0, 0),
                Language = "English",
                DriversNeeded = 3,
                Active = true,
            };

            var templateThree = new GatheringTemplate
            {
                Id = 3,
                DayOfWeek = System.DayOfWeek.Saturday,
                TimeOfDay = new System.TimeSpan(10, 0, 0),
                Language = "English",
                DriversNeeded = 3,
                Active = true,
            };

            context.AddRange(templateOne, templateTwo, templateThree);

            context.SaveChanges();
        }
    }
}
