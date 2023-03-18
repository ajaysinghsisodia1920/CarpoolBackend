using Carpool.DataStorage;
using Carpool.Model;
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
        public List<OfferedRides> GetAllOfferingRides()
        {
            //List<OfferingRides> offeringRides= new List<OfferingRides>();
            //offeringRides.Add(new OfferingRides("a","b"));
            // return offeringRides;
            List<OfferingRides> offeringRides = Context.Offerings.ToList<OfferingRides>();
            List<OfferedRides> _offeredRides = new List<OfferedRides>();
            foreach (var offering in offeringRides)
            {
                OfferedRides offered = new OfferedRides();
                offered.Source = offering.Source;
                offered.Destination = offering.Destination;
                _offeredRides.Add(offered);
            }
            return _offeredRides;
        }

        public List<OfferedRides> GetAllOfferedRidesHistoryForUser(string email)
        {
            int userId = SharedService.GetUserId(email);
            List<OfferingRides> offeredRides = Context.Offerings.Where(u => u.UserId == userId && u.RideBookerName!="").ToList<OfferingRides>();
            List<OfferedRides> _offeredRides = new List<OfferedRides>();
            foreach (var offering in offeredRides)
            {
                OfferedRides offered = new OfferedRides();
                offered.Source = offering.Source;
                offered.Destination = offering.Destination;
                offered.Name = offering.RideBookerName;
                _offeredRides.Add(offered);
            }
            return _offeredRides;
        }

        public List<OfferedRides> SearchOfferingRides(string email, string source, string destination)
        {
            int userId = SharedService.GetUserId(email);
            List<OfferingRides> offeringRides = Context.Offerings.Where(u => u.UserId != userId && u.Source == source && u.Destination == destination && u.UserId!=-1).ToList<OfferingRides>();
            List<OfferedRides> _offeredRides = new List<OfferedRides>();
            foreach (var offering in offeringRides)
            {
                int uid = offering.UserId;
                string userName = SharedService.GetUserName(uid);
                OfferedRides offered = new OfferedRides();
                offered.Source = offering.Source;
                offered.Destination = offering.Destination;
                offered.Name = userName;
                _offeredRides.Add(offered);
            }
            return _offeredRides;
        }

        public bool AddOfferingRides(string email, OfferingRides offeringRides)
        {
            int userId = SharedService.GetUserId(email);
            offeringRides.UserId = userId;
            Context.Offerings.Add(offeringRides);
            Context.SaveChanges();
            return true;
        }
    }
}
