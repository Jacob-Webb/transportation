using System;
using AutoMapper;
using TransportationAPI.Models;
using TransportationAPI.DTOs;
using TransportationAPI.Types;

namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            // User data class has direct correlation to UserDTO fields and it goes in both direction.
            CreateMap<ApplicationUser, UserLoginDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<EventTemplate, EventTemplateDto>()
                .ForSourceMember(x => x.EventTemplateBoundaries, y => y.DoNotValidate())
                .ReverseMap();
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
        }
    }

    public class TimeSpanTypeConverter : ITypeConverter<TimeOfDay, TimeSpan>
    {
        public TimeSpan Convert(TimeOfDay source, TimeSpan destination, ResolutionContext context)
        {
            return new TimeSpan(source.Hour, source.Minutes, 0);
        }
    }

    public class TimeOfDayTypeConverter : ITypeConverter<TimeSpan, TimeOfDay>
    {
        public TimeOfDay Convert(TimeSpan source, TimeOfDay destination, ResolutionContext context)
        {
            return new TimeOfDay(source.Hours, source.Minutes);
        }
    }
}
