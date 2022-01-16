using System;
using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class Gathering
    {
        public Gathering()
        {
            ScheduledRides = new HashSet<ScheduledRide>();
            CancelledRides = new HashSet<CancelledRide>();
            Routes = new HashSet<Route>();
        }

        public int Id { get; set; }

        public DateTime DateAndTime { get; set; }

        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }

        public virtual ICollection<CancelledRide> CancelledRides { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public GatheringTemplate Template { get; set; }
    }
}
