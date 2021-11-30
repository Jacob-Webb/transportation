using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class UserCoordinate
    {
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Coordinate")]
        public int CoordinateId { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
