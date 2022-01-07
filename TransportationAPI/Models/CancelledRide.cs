using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class CancelledRide
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Gathering")]
        public int GatheringId { get; set; }

        public Gathering Gathering { get; set; }

        public Note Note { get; set; }

        public Source Source { get; set; }
    }
}
