using System;
using AutoMapper;
using NUnit.Framework;
using TransportationAPI.Configurations.Mapper;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPITests
{
    [TestFixture]
    public class MapperInitializerTests
    {
        MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ApplicationUser, AuthenticationDto>().ReverseMap();
            cfg.CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            cfg.CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new TimeSpanDtoTypeConverter());
            cfg.CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new TimeSpanTypeConverter());
            cfg.CreateMap<Coordinate, CoordinateDto>().ReverseMap();

        // For this, I need to map from Coordinate to EventTemplateBoundary or ignore them and assign in code
        // Let's try ignoring for now.
        cfg.CreateMap<EventTemplate, CreateEventTemplateDto>()
            .ForMember(dest => dest.BoundaryCoordinates, opt => opt.Ignore());
        });

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Configuration_IsValid()
        {
            _config.AssertConfigurationIsValid();
        }



    }

}
