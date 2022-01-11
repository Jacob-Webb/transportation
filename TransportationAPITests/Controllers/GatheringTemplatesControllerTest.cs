using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;
using TransportationAPI.Configurations;
using TransportationAPI.Controllers;
using TransportationAPI.DTOs;
using TransportationAPI.IRepository;
using TransportationAPI.Models;
using TransportationAPI.Repository;

namespace TransportationAPITests.Controllers
{
    [TestFixture]
    public class GatheringTemplatesControllerTest
    {
        // Need ILogger for Controller Constructor dependency.
        private readonly Mock<ILogger<GatheringTemplatesController>> _mockLogger;

        // Need IMapper for Controller Constructor dependency.
        private readonly IMapper _mapper;

        private DbContextOptions<ApplicationDbContext> _options;
        private IUnitOfWork _unitOfWork;
        private GatheringTemplatesController _templatesController;

        public GatheringTemplatesControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperInitializer());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _mockLogger = new Mock<ILogger<GatheringTemplatesController>>();
        }

        protected DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        // Initialize in memory db context, unitOfWork, and GatheringTemplatesController.
        [OneTimeSetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GatheringTemplatesDatabase")
                .Options;

            var context = new ApplicationDbContext(_options);
            _unitOfWork = new UnitOfWork(context);
            _templatesController = new GatheringTemplatesController(
                _unitOfWork,
                _mockLogger.Object,
                _mapper);
        }

        [Test]
        public async Task CreateTemplate_ModelIsValid_ReturnsId()
        {
            // Assign
            var createTemplateDto = new CreateGatheringTemplateDto
            {
                DayOfWeek = System.DayOfWeek.Wednesday,
                TimeOfDay = new TimeSpanDto(19, 0),
                Language = "English",
                DriversNeeded = 3,
                Active = true,
            };

            // Act
            var template = await _templatesController.CreateTemplate(createTemplateDto);
            CreatedAtRouteResult creationResult = template as CreatedAtRouteResult;

            // Assert
            Assert.That(template, Is.TypeOf<CreatedAtRouteResult>());
            Assert.That(creationResult.Value, Is.TypeOf<TransportationAPI.Models.GatheringTemplate>());
            Assert.That(creationResult.StatusCode, Is.EqualTo(201));
            Assert.That(creationResult.RouteName, Is.EqualTo("GetTemplate"));
        }
    }
}
