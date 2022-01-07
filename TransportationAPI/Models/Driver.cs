using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransportationAPI.Models
{
    public class Driver
    {
        public Driver()
        {
            RouteDrivers = new HashSet<RouteDriver>();
        }

        public int Id { get; set; }

        public virtual ICollection<RouteDriver> RouteDrivers { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
