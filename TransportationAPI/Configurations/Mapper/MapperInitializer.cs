using System;
using AutoMapper;
using TransportationAPI.Models;
using TransportationAPI.DTOs;
using TransportationAPI.Configurations.Mapper;

namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            // User data class has direct correlation to UserDTO fields and it goes in both direction.
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new TimeSpanDtoTypeConverter());
            CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();

            // For this, I need to map from Coordinate to EventTemplateBoundary or ignore them and assign in code
            // Let's try ignoring for now.
            CreateMap<EventTemplate, CreateEventTemplateDto>();
            CreateMap<CreateEventTemplateDto, EventTemplate>();
        }
    }
}
