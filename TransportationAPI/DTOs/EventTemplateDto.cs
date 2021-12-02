using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;

namespace TransportationAPI.DTOs
{
    public class CreateEventTemplateDto
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
}
