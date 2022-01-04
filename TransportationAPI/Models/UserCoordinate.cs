namespace TransportationAPI.Models
{
    public class UserCoordinate
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public double CoordinateLatitude { get; set; }

        public double CoordinateLongitude { get; set; }

        public virtual Coordinate Coordinate { get; set; }
    }
}
