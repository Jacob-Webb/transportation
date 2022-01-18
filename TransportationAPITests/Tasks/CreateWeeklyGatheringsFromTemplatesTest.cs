using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using TransportationAPI.IRepository;
using TransportationAPI.Models;
using TransportationAPI.Repository;
using TransportationAPI.Tasks;

namespace TransportationAPITests.Tasks
{
    [TestFixture]
    public class CreateWeeklyGatheringsFromTemplatesTest
    {
        private DbContextOptions<ApplicationDbContext> _options;
        private IUnitOfWork _unitOfWork;
        private Mock<ILogger<CreateWeeklyGatheringsFromTemplates>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TemplatesDatabase")
                .Options;

            var context = new ApplicationDbContext(_options);
            Seed(context);
            _unitOfWork = new UnitOfWork(context);
            _mockLogger = new Mock<ILogger<CreateWeeklyGatheringsFromTemplates>>();
        }

        [Test]
        public void Execute_NoUpcomingGatherings_AllGatheringsCreated()
        {
            // Assign
            var job = new CreateWeeklyGatheringsFromTemplates(_unitOfWork, _mockLogger.Object);
            var mockIJobExecutionContext = new Mock<IJobExecutionContext>();

            // Act
            job.Execute(mockIJobExecutionContext.Object);

            List<Gathering> result = _unitOfWork.Gatherings.GetAll().ToList();

            // Assert
            mockIJobExecutionContext.VerifyAll();
            Assert.That(result, Is.TypeOf<List<Gathering>>());
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].DateAndTime.DayOfWeek, Is.EqualTo(System.DayOfWeek.Wednesday));
            Assert.That(result[1].DateAndTime.DayOfWeek, Is.EqualTo(System.DayOfWeek.Saturday));
            Assert.That(result[2].DateAndTime.DayOfWeek, Is.EqualTo(System.DayOfWeek.Sunday));
        }

        [Test]
        public void Execute_GatheringsAlreadyExist_ReturnsNoNewGatherings()
        {
            // Assign
            var gatheringOne =
                new Gathering
                {
                    DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 23, 9, 0, 0),
                };
            var gatheringTwo =
                new Gathering
                {
                    DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 19, 19, 0, 0),
                };
            var gatheringThree =
                new Gathering
                {
                    DateAndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 22, 10, 0, 0),
                };

            _unitOfWork.Gatherings.Insert(gatheringOne);
            _unitOfWork.Gatherings.Insert(gatheringTwo);
            _unitOfWork.Gatherings.Insert(gatheringThree);
            _unitOfWork.Save();

            var job = new CreateWeeklyGatheringsFromTemplates(_unitOfWork, _mockLogger.Object);
            var mockIJobExecutionContext = new Mock<IJobExecutionContext>();

            // Act
            job.Execute(mockIJobExecutionContext.Object);

            List<Gathering> result = _unitOfWork.Gatherings.GetAll().ToList();

            // Assert
            mockIJobExecutionContext.VerifyAll();
            Assert.That(result, Is.TypeOf<List<Gathering>>());
            Assert.That(result, Has.Count.EqualTo(3));
            Assert.That(result[0].Id, Is.EqualTo(3));
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
