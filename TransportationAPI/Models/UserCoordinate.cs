using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class UserCoordinate
    {
        //[ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        //[ForeignKey("Coordinate")]
        public double CoordinateLatitude { get; set; }
        public double CoordinateLongitude { get; set; }
        public virtual Coordinate Coordinate { get; set; }
    }
}
