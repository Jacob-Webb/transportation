using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportationAPI.DTOs
{
    #pragma warning disable SA1402 // File may only contain a single type
    #pragma warning disable SA1649 // File name should match first type name
    public class CreateEventTemplateDto
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

    public class EventTemplateDto : CreateEventTemplateDto
    {
        public int Id { get; set; }
    }

    public class UpdateEventTemplateDto : CreateEventTemplateDto
    {
    }
    #pragma warning restore SA1402 // File may only contain a single type
}
