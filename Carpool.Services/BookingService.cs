using Carpool.Model;
using Carpool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class BookingService : IBookingService
    {
       private readonly Carpool.DataStorage.CarpoolContext context;

       private readonly ISharedService sharedService;
        
       public BookingService(Carpool.DataStorage.CarpoolContext context,ISharedService sharedService)
       {
            this.context = context;
            this.sharedService= sharedService;
       }

       public List<BookedRides> GetAllBookedRides()
        {
            //List<Carpool.DataStorage.BookedRides> bookedRides=context.BookedRides.ToList();
            return new List<BookedRides>();
        }
    
        public bool BookRide(string email,string rideOfferName,string source,string destination)
        {
            int userId = sharedService.GetUserId(email);
            Carpool.DataStorage.BookedRides bookedRides=new Carpool.DataStorage.BookedRides();
            bookedRides.UserId = userId;
            bookedRides.Source = source;
            bookedRides.Destination = destination;
            bookedRides.RideOfferName = rideOfferName;
            context.BookedRides.Add(bookedRides);
            context.SaveChanges();
            return true;
        }

        public List<BookedRides> GetBookedRidesHistory(string email)
        {
            int userId = sharedService.GetUserId(email);
            List<Carpool.DataStorage.BookedRides> bookedRides = context.BookedRides.Where(u=>u.UserId== userId).ToList();
            List<BookedRides> bookedRides1= new List<BookedRides>();
            foreach(var ride in bookedRides){
                BookedRides rides= new BookedRides();
                rides.Name = ride.RideOfferName;
                rides.Source = ride.Source;
                rides.Destination=ride.Destination;
                bookedRides1.Add(rides);
            }
            return bookedRides1;
        }
    }
}
