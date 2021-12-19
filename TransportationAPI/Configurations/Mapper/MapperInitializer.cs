using System;
using AutoMapper;
using TransportationAPI.Models;
using TransportationAPI.DTOs;
using TransportationAPI.Configurations.Mapper;

namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        /// <summary>
        /// Creates the mappings for classes.
        /// </summary>
        public MapperInitializer()
        {
            CreateMap<ApplicationUser, AuthenticationDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new TimeSpanDtoTypeConverter());
            CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();

            CreateMap<EventTemplate, CreateEventTemplateDto>();
            CreateMap<CreateEventTemplateDto, EventTemplate>();
        }
    }
}
