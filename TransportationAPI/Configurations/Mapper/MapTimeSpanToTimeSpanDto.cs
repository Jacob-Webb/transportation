using AutoMapper;
using System;
using TransportationAPI.DTOs;

namespace TransportationAPI.Configurations.Mapper
{
    public class MapTimeSpanToTimeSpanDto : ITypeConverter<TimeSpan, TimeSpanDto>
    {
        public TimeSpanDto Convert(TimeSpan source, TimeSpanDto destination, ResolutionContext context)
        {
            return new TimeSpanDto(source.Hours, source.Minutes);
        }
    }
}
