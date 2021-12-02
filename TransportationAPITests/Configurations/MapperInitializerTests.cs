using System;
using AutoMapper;
using NUnit.Framework;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPITests
{
    [TestFixture]
    public class MapperInitializerTests
    {
        MapperConfiguration _config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TimeSpanDto, TimeSpan>();
            cfg.CreateMap<EventTemplateDto, EventTemplate>()
                .ForMember(dest => dest.EventTemplateBoundaries, opt => opt.Ignore());
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
    public class TimeSpanTypeConverter : ITypeConverter<TimeSpanDto, TimeSpan>
    {
        public TimeSpan Convert(TimeSpanDto source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.Hour, source.Minutes, 0);
        }
    }
}
