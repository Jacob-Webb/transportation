using System;
using System.Collections.Generic;
using TransportationAPI.Types;

namespace TransportationAPI.Data
{
    public class EventTemplate
    {
        public EventTemplate()
        {
            this.EventTemplateBoundaries = new HashSet<EventTemplateBoundary>();
        }
        public int Id { get; set; }
        /// <summary>Indicates the day of the week.</summary>
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOfDay TimeOfDay { get; set; }
        public string Language { get; set; }
        public int DriversNeeded { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
    }
}
