using System;
using AutoMapper;
namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            // User data class has direct correlation to UserDTO fields and it goes in both direction.

            CreateMap<ApplicationUser, UserLoginDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<EventTemplate, EventTemplateDto>().ReverseMap();
            CreateMap<EventTemplate, CreateEventTemplateDto>().ReverseMap();
        }
    }
}
