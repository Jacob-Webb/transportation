using AutoMapper;
using System;
using TransportationAPI.DTOs;

namespace TransportationAPI.Configurations.Mapper
{

    public class MapTimeSpanDtoToTimeSpan : ITypeConverter<TimeSpanDto, TimeSpan>
    {
        public TimeSpan Convert(TimeSpanDto source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.Hours, source.Minutes, 0);
        }
    }
}
