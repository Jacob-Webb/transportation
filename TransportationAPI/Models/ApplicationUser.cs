using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TransportationAPI.Data
{
    /*
    * ApplicationUser initially taken from database first design from legacy code 
    *
    */
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.UserCoordinates = new HashSet<UserCoordinate>();
            this.CancelledRides = new HashSet<CancelledRide>();
            this.ScheduledRides = new HashSet<ScheduledRide>();
            this.UserNotes = new HashSet<UserNote>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool RequiresWheelchair { get; set; }
        public virtual ICollection<UserCoordinate> UserCoordinates { get; set; }
        public virtual ICollection<CancelledRide> CancelledRides { get; set; }
        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }
        public virtual ICollection<UserNote> UserNotes { get; set; }
    }
}
