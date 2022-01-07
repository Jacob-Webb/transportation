namespace TransportationAPI.Models
{
    public class GatheringTemplateBoundary
    {
        public int GatheringTemplateId { get; set; }

        public GatheringTemplate GatheringTemplates { get; set; }

        public double CoordinateLatitude { get; set; }

        public double CoordinateLongitude { get; set; }

        public Coordinate Coordinates { get; set; }
    }
}
