using System.ComponentModel.DataAnnotations;

namespace Carpool.DataStorage
{
    public class BookedRides
    {
        [Key]
        public int Id { get; set; }

        public string RideOfferName { get; set; }
        public string Source { get; set; }

        public string Destination { get; set; }

        public DateTime BookingDate { get; set; }

        public TimeSpan BookingTime { get; set; }

        public int UserId { get; set; }
    }
}