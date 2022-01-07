using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class ScheduledRide
    {
        public int Id { get; set; }

        public int PassengerCount { get; set; }

        public DateTime TimeScheduled { get; set; }

        public Route Route { get; set; }

        public Source Source { get; set; }

        [ForeignKey("Gathering")]
        public int GatheringId { get; set; }

        public Gathering Gathering { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
