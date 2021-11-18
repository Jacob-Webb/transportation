using System;
using System.Collections.Generic;

namespace TransportationAPI.Data
{
    public class Note
    {
        public Note()
        {
            this.UserNotes = new HashSet<UserNote>();
            this.CancelledRides = new HashSet<CancelledRide>();
        }
        public int Id { get; set; }
        public string Message { get; set; }
        public virtual ICollection<UserNote> UserNotes { get; set; }
        public virtual ICollection<CancelledRide> CancelledRides { get; set; }
    }
}
