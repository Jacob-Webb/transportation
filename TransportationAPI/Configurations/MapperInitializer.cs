using System;
using AutoMapper;
using TransportationAPI.Models;
using TransportationAPI.DTOs;

namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            // User data class has direct correlation to UserDTO fields and it goes in both direction.
            CreateMap<ApplicationUser, UserLoginDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new TimeSpanDtoTypeConverter());
            CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();
            CreateMap<EventTemplate, CreateEventTemplateDto>().ReverseMap();
        }
    }

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
