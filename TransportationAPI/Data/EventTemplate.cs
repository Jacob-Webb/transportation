using System;
using System.Collections.Generic;

namespace TransportationAPI.Data
{
    public class EventTemplate
    {
        public EventTemplate()
        {
            this.Events = new HashSet<Event>();
            this.EventTemplateBoundaries = new HashSet<EventTemplateBoundary>();
        }
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime TimeOfDay { get; set; }
        public string Language { get; set; }
        public int DriversNeeded { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
