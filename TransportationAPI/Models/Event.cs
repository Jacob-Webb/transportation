using System;
using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class Event
    {
        public Event()
        {
            ScheduledRides = new HashSet<ScheduledRide>();
            CancelledRides = new HashSet<CancelledRide>();
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }

        public DateTime EventDateTime { get; set; }

        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }

        public virtual ICollection<CancelledRide> CancelledRides { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public EventTemplate Template { get; set; }
    }
}
