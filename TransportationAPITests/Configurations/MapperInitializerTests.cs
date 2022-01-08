﻿using AutoMapper;
using NUnit.Framework;
using System;
using TransportationAPI.Configurations.Mapper;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPITests
{
    [TestFixture]
    public class MapperInitializerTests
    {
        private readonly MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ApplicationUser, AuthenticationDto>().ReverseMap();
            cfg.CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            cfg.CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new MapTimeSpanToTimeSpanDto());
            cfg.CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new MapTimeSpanDtoToTimeSpan());
            cfg.CreateMap<Coordinate, CoordinateDto>().ReverseMap();

            // For this, I need to map from Coordinate to GatheringTemplateBoundary or ignore them and assign in code
            // Let's try ignoring for now.
            cfg.CreateMap<GatheringTemplate, CreateGatheringTemplateDto>()
            .ForMember(dest => dest.BoundaryCoordinates, opt => opt.Ignore());
        });

        [SetUp]
        public void Setup()
        {
            // Method intentionally left empty.
        }

        [Test]
        public void Configuration_IsValid()
        {
            _config.AssertConfigurationIsValid();
        }
    }
}
