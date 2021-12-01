using System;
using AutoMapper;
using NUnit.Framework;
using TransportationAPI.DTOs;
using TransportationAPI.Models;
using TransportationAPI.Types;

namespace TransportationAPITests
{
    [TestFixture]
    public class MapperInitializerTests
    {
        MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TimeOfDay, TimeSpan>();
            cfg.CreateMap<EventTemplateDto, EventTemplate>()
                .ForMember(dest => dest.EventTemplateBoundaries, opt => opt.MapFrom(src => src.BoundaryCoordinates));
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
    public class TimeSpanTypeConverter : ITypeConverter<TimeOfDay, TimeSpan>
    {
        public TimeSpan Convert(TimeOfDay source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.Hour, source.Minutes, 0);
        }
    }
}
