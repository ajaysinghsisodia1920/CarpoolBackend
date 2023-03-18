using Carpool.DataStorage;
using Carpool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IOfferingService
    {
       public List<OfferedRides> GetAllOfferingRides();    
       
       public List<OfferedRides> GetAllOfferedRidesHistoryForUser(string email);

        public List<OfferedRides> SearchOfferingRides(string email, string source, string destination);

        public bool AddOfferingRides(string email,OfferingRides offeringRides);
    }
}
