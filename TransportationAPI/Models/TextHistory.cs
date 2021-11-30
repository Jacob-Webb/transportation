using System;
namespace TransportationAPI.Models
{
    public class TextHistory
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime TextTimeStamp { get; set; }
        public string Message { get; set; }
    }
}
