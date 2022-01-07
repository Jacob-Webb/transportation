﻿using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class Coordinate
    {
        public Coordinate()
        {
            UserCoordinates = new HashSet<UserCoordinate>();
            GatheringTemplateBoundaries = new HashSet<GatheringTemplateBoundary>();
        }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<UserCoordinate> UserCoordinates { get; set; }

        public virtual ICollection<GatheringTemplateBoundary> GatheringTemplateBoundaries { get; set; }
    }
}
