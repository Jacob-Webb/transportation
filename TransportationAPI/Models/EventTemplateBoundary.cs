namespace TransportationAPI.Models
{
    public class EventTemplateBoundary
    {
        public int EventTemplateId { get; set; }

        public EventTemplate EventTemplates { get; set; }

        public double CoordinateLatitude { get; set; }

        public double CoordinateLongitude { get; set; }

        public Coordinate Coordinates { get; set; }
    }
}
