using Carpool.Model;
using Carpool.Services;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("devCorsPolicy")]
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost("BookRide")]
        public IActionResult BookRide(string email, string rideOfferName, string source, string destination)
        {
            return Ok(bookingService.BookRide(email, rideOfferName, source, destination));
        }

        [HttpGet("GetBookedRides")]
        public IActionResult GetBookedRidesHistory(string email)
        {
            return Ok(bookingService.GetBookedRidesHistory(email));
        }
    }
}
