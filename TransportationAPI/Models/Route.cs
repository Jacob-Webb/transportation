using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Data
{
    public class Route
    {
        public Route()
        {
            this.RouteDrivers = new HashSet<RouteDriver>();
            this.ScheduledRides = new HashSet<ScheduledRide>();
        }
        public int Id { get; set; }
        public virtual ICollection<RouteDriver> RouteDrivers { get; set; }
        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
