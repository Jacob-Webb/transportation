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
            CreateMap<ApplicationUser, AuthenticationDto>().ForMember(dest => dest.Password, act => act.Ignore()).ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ForMember(dest => dest.Password, act => act.Ignore()).ReverseMap();
            CreateMap<TimeSpan, TimeSpanDto>().ConvertUsing(new MapTimeSpanToTimeSpanDto());
            CreateMap<TimeSpanDto, TimeSpan>().ConvertUsing(new MapTimeSpanDtoToTimeSpan());
            CreateMap<Coordinate, CoordinateDto>().ReverseMap();

            CreateMap<GatheringTemplate, GatheringTemplateDto>().ForMember(dest => dest.BoundaryCoordinates, opt => opt.Ignore());
            CreateMap<CreateGatheringTemplateDto, GatheringTemplate>().ForMember(dest => dest.GatheringTemplateBoundaries, opt => opt.Ignore());
        }
    }
}
