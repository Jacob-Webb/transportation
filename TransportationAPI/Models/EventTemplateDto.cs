using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TransportationAPI.Data;

namespace TransportationAPI.Models
{
    public class CreateEventTemplateDto
    {
        [Required]
        [Range(0, 6)]
        public int DayOfWeek { get; set; }
        [Required]
        public TimeSpan TimeOfDay { get; set; }
        public int DriversNeeded { get; set; }
        public bool Active { get; set; }
        public HashSet<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
    }
    public class EventTemplateDto : CreateEventTemplateDto
    {
        public int Id { get; set; }
    }

    public class UpdateEventTemplateDto : CreateEventTemplateDto
    {

    }
}
