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
            //CreateMap<EventTemplate, EventTemplateDto>().ReverseMap();
            //CreateMap<EventTemplateDto, EventTemplate>();
            CreateMap<EventTemplate, CreateEventTemplateDto>().ReverseMap();
        }
    }

    //public class CustomTimeResolver : IValueResolver<TimeOfDay, TimeSpan, TimeSpan>
    //{
    //    public TimeSpan Resolve(TimeOfDay source, TimeSpan destination, TimeSpan member, ResolutionContext context)
    //    {
    //        return new TimeSpan(source.Hour, source.Minutes, 0);
    //    }
    //}
}
