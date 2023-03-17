using Carpool.DataStorage;
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
        private readonly CarpoolContext context; 
       public BookingService(CarpoolContext context)
       {
            this.context = context;
       }

       public List<BookedRides> GetAllBookedRides()
        {
            return context.BookedRides.ToList();
        }
      
    }
}
