using System;
using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class Coordinate
    {
        public Coordinate()
        {
            this.UserCoordinates = new HashSet<UserCoordinate>();
            this.EventTemplateBoundaries = new HashSet<EventTemplateBoundary>();
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public virtual ICollection<UserCoordinate> UserCoordinates { get; set; }
        public virtual ICollection<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
    }
}
