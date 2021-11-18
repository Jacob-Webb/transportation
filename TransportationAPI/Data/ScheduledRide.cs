using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Data
{
    public class ScheduledRide
    {
        public int Id { get; set; }
        public int PassengerCount { get; set; }
        public DateTime TimeScheduled { get; set; }
        public Route Route { get; set; }
        public Source Source { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
