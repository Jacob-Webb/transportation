using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserCoordinates = new HashSet<UserCoordinate>();
            CancelledRides = new HashSet<CancelledRide>();
            ScheduledRides = new HashSet<ScheduledRide>();
            UserNotes = new HashSet<UserNote>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public bool RequiresWheelchair { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public virtual ICollection<UserCoordinate> UserCoordinates { get; set; }

        public virtual ICollection<CancelledRide> CancelledRides { get; set; }

        public virtual ICollection<ScheduledRide> ScheduledRides { get; set; }

        public virtual ICollection<UserNote> UserNotes { get; set; }
    }
}
