using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class UserNote
    {
        [ForeignKey("Note")]
        public int NoteId { get; set; }

        public Note Note { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
