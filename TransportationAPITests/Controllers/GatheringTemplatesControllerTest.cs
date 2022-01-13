using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        /// <summary>
        /// Initialize the database with values at the start of every test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "GatheringTemplatesDatabase")
                .Options;

            var context = new ApplicationDbContext(_options);
            Seed(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [Test]
        public void TestModelValidation_ModelStateIsNotValid_ReturnsFalse()
        {
            var dataModel = new GatheringTemplateDto();

            var context = new System.ComponentModel.DataAnnotations.ValidationContext(dataModel);
            var results = new List<ValidationResult>();
            var isModelStateValid = Validator.TryValidateObject(dataModel, context, results, true);

            Assert.That(isModelStateValid, Is.EqualTo(false));
        }

        [Test]
        public async Task CreateTemplate_ModelIsValid_ReturnsAcceptedCreatedAtRouteResult()
        {
            // Assign
            var controller = new GatheringTemplatesController(
                 _unitOfWork,
                 _mockLogger.Object,
                 _mapper);

            var createTemplateDto = new CreateGatheringTemplateDto
            {
                DayOfWeek = System.DayOfWeek.Wednesday,
                TimeOfDay = new TimeSpanDto(19, 0),
                Language = "English",
                DriversNeeded = 3,
                Active = true,
            };

            // Act
            var template = await controller.CreateTemplate(createTemplateDto);
            CreatedAtRouteResult creationResult = template as CreatedAtRouteResult;

            // Assert
            Assert.That(template, Is.TypeOf<CreatedAtRouteResult>());
            Assert.That(creationResult.Value, Is.TypeOf<TransportationAPI.Models.GatheringTemplate>());
            Assert.That(creationResult.StatusCode, Is.EqualTo(201));
            Assert.That(creationResult.RouteName, Is.EqualTo("GetTemplate"));
        }

        [Test]
        public async Task CreateTemplate_ModelIsInvalid_ReturnsBadRequest()
        {
            // Assign
            var controller = new GatheringTemplatesController(
                 _unitOfWork,
                 _mockLogger.Object,
                 _mapper);

            controller.ModelState.AddModelError("test", "test");

            // Act
            var result = await controller.CreateTemplate(new CreateGatheringTemplateDto());

            // Assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetTemplateById_IdIsValid_ReturnsTemplateById()
        {
            // Assign
            var controller = new GatheringTemplatesController(
                _unitOfWork,
                _mockLogger.Object,
                _mapper);

            // Act
            var template = await controller.GetTemplateById(1);
            var result = template as OkObjectResult;
            GatheringTemplateDto templateDto = result.Value as GatheringTemplateDto;

            // Assert
            Assert.That(template, Is.TypeOf<OkObjectResult>());
            Assert.That(result.Value, Is.TypeOf<GatheringTemplateDto>());
            Assert.That(templateDto.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task GetTemplateById_IdIsOutOfRange_ReturnsBadRequest()
        {
            // Assign
            var controller = new GatheringTemplatesController(
                _unitOfWork,
                _mockLogger.Object,
                _mapper);

            // Act
            var template = await controller.GetTemplateById(-1);
            var result = template as BadRequestObjectResult;

            // Assert
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task GetAllTemplates_CollectionIsNotEmpty_ReturnsCollectionOfTemplate()
        {
            var controller = new GatheringTemplatesController(
                _unitOfWork,
                _mockLogger.Object,
                _mapper);

            var templates = await controller.GetAllTemplates();
            var result = templates as OkObjectResult;
            var values = (List<GatheringTemplateDto>)result.Value;

            Assert.That(values, Is.TypeOf<List<GatheringTemplateDto>>());
            Assert.That(values, Has.Count.EqualTo(3));
            Assert.That(values[0].Id, Is.EqualTo(1));
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
