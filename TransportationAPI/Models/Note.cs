using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class Note
    {
        public Note()
        {
            UserNotes = new HashSet<UserNote>();
            CancelledRides = new HashSet<CancelledRide>();
        }

        public int Id { get; set; }

        public string Message { get; set; }

        public virtual ICollection<UserNote> UserNotes { get; set; }

        public virtual ICollection<CancelledRide> CancelledRides { get; set; }
    }
}
