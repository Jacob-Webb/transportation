using System;
using System.Collections.Generic;

namespace TransportationAPI.Data
{
    public class Event
    {
        public Event()
        {
            this.ScheduledRides = new HashSet<ScheduledRide>();
            this.CancelledRides = new HashSet<CancelledRide>();
            this.Routes = new HashSet<Route>();
        }
        public int Id { get; set; }
        public DateTime EventDateTime { get; set; }
        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }
        public virtual ICollection<CancelledRide> CancelledRides { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
        public EventTemplate Template { get; set; }
    }
}
