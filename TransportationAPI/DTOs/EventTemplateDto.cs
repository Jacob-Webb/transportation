﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TransportationAPI.Models;
using TransportationAPI.Types;

namespace TransportationAPI.DTOs
{
    public class CreateEventTemplateDto
    {
        
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        //[Required]
        //public int Hour { get; set; }
        //[Required]
        //public int Minutes { get; set; }
        public string Language { get; set; }
        public int DriversNeeded { get; set; }
        public bool Active { get; set; }
        public HashSet<List<float>> BoundaryCoordinates { get; set; }
    }
    public class EventTemplateDto : CreateEventTemplateDto
    {
        public int Id { get; set; }
    }

    public class UpdateEventTemplateDto : CreateEventTemplateDto
    {

    }
}
