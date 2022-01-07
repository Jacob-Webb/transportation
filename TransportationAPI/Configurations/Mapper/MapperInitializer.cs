using AutoMapper;
using System;
using TransportationAPI.Configurations.Mapper;
using TransportationAPI.DTOs;
using TransportationAPI.Models;

namespace TransportationAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperInitializer"/> class.
        /// Creates the mappings for classes.
        /// </summary>
        public MapperInitializer()
        {
            CreateMap<ApplicationUser, AuthenticationDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new MapTimeSpanToTimeSpanDto());
            CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new MapTimeSpanDtoToTimeSpan());
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();

            CreateMap<GatheringTemplate, CreateGatheringTemplateDto>();
            CreateMap<CreateGatheringTemplateDto, GatheringTemplate>();
        }
    }
}
