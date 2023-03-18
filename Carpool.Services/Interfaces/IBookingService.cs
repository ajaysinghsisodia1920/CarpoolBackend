using Carpool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IBookingService
    {
        public List<BookedRides> GetAllBookedRides();

        public bool BookRide(string email, string rideOfferName, string source, string destination);

        public List<BookedRides> GetBookedRidesHistory(string email);
    }
}
