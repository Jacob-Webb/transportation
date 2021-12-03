using System;
using AutoMapper;
using TransportationAPI.DTOs;

namespace TransportationAPI.Configurations.Mapper
{
    public class TimeSpanTypeConverter : ITypeConverter<TimeSpanDto, TimeSpan>
    {
        public TimeSpan Convert(TimeSpanDto source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.Hours, source.Minutes, 0);
        }
    }

    public class TimeSpanDtoTypeConverter : ITypeConverter<TimeSpan, TimeSpanDto>
    {
        public TimeSpanDto Convert(TimeSpan source, TimeSpanDto destination, ResolutionContext context)
        {
            return new TimeSpanDto(source.Hours, source.Minutes);
        }
    }
}
