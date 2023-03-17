using Carpool.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IOfferingService
    {
       public List<OfferingRides> GetAllOfferingRides();    
       
       public List<OfferingRides> GetAllOfferedRidesHistoryForUser(string email);

        public List<OfferingRides> SearchOfferingRides(string email, string source, string destination, DateOnly rideDate, TimeSpan rideStartTime);

        public bool AddOfferingRides(string email,OfferingRides offeringRides);
    }
}
