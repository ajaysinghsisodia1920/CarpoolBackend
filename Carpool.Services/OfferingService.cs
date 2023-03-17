using Carpool.DataStorage;
using Carpool.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class OfferingService:IOfferingService
    {
        public CarpoolContext Context;

        public ISharedService SharedService;

        public OfferingService(CarpoolContext context,ISharedService sharedService)
        {
            this.Context= context;
            this.SharedService = sharedService;
        }
        public List<OfferingRides> GetAllOfferingRides()
        {
            //List<OfferingRides> offeringRides= new List<OfferingRides>();
            //offeringRides.Add(new OfferingRides("a","b"));
            // return offeringRides;
            return Context.Offerings.ToList<OfferingRides>();
        }

        public List<OfferingRides> GetAllOfferedRidesHistoryForUser(string email)
        {
            int userId = SharedService.GetUserId(email);
            List<OfferingRides> offeredRides = Context.Offerings.Where(u => u.UserId == userId).ToList<OfferingRides>();
            return offeredRides;
        }

        public List<OfferingRides> SearchOfferingRides(string email, string source, string destination, DateOnly rideDate, TimeSpan rideStartTime)
        {
            int userId = SharedService.GetUserId(email);
            List<OfferingRides> offeringRides= Context.Offerings.Where(u=>u.UserId!=userId && u.Source==source && u.Destination==destination).ToList<OfferingRides>();
            return offeringRides;
        }

        public bool AddOfferingRides(string email,OfferingRides offeringRides)
        {
            int userId=SharedService.GetUserId(email);
            offeringRides.UserId = userId;
            Context.Offerings.Add(offeringRides);
            Context.SaveChanges();
            return true;
        }
    }
}
