using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class CancelledRide
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public Note Note { get; set; }

        public Source Source { get; set; }
    }
}
