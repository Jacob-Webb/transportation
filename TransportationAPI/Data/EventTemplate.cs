using System;
using System.Collections.Generic;

namespace TransportationAPI.Data
{
    public class EventTemplate
    {
        public EventTemplate()
        {
            this.EventTemplateBoundaries = new HashSet<EventTemplateBoundary>();
        }
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public TimeSpan TimeOfDay { get; set; }
        public string Language { get; set; }
        public int DriversNeeded { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
    }
}
