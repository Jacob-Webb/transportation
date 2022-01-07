using System;
using System.Collections.Generic;

namespace TransportationAPI.Models
{
    public class GatheringTemplate
    {
        public GatheringTemplate()
        {
            GatheringTemplateBoundaries = new HashSet<GatheringTemplateBoundary>();
        }

        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan TimeOfDay { get; set; }

        public string Language { get; set; }

        public int DriversNeeded { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<GatheringTemplateBoundary> GatheringTemplateBoundaries { get; set; }
    }
}
