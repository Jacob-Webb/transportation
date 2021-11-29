using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Data
{
    public class RouteDriver
    {
        [ForeignKey("Driver")]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
