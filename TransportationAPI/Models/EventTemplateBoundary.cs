using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class EventTemplateBoundary
    {
        //[ForeignKey("EventTemplate")]
        public int EventTemplateId { get; set; }
        public EventTemplate EventTemplates { get; set; }

        //[ForeignKey("Coordinate")]
        public double CoordinateLatitude { get; set; }
        public double CoordinateLongitude { get; set; }
        public Coordinate Coordinates { get; set; }
    }
}
