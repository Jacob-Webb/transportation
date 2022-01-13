using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportationAPI.DTOs
{
    #pragma warning disable SA1402 // File may only contain a single type
    #pragma warning disable SA1649 // File name should match first type name
    public class CreateGatheringTemplateDto
    #pragma warning restore SA1649 // File name should match first type name
    {
        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public TimeSpanDto TimeOfDay { get; set; }

        public string Language { get; set; }

        public int DriversNeeded { get; set; }

        public bool Active { get; set; }

        public HashSet<CoordinateDto> BoundaryCoordinates { get; set; }
    }

    public class GatheringTemplateDto : CreateGatheringTemplateDto
    {
        public int Id { get; set; }
    }

    public class UpdateGatheringTemplateDto : CreateGatheringTemplateDto
    {
    }
    #pragma warning restore SA1402 // File may only contain a single type
}
