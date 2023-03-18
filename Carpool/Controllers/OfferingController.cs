using Carpool.DataStorage;
using Carpool.Services;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("devCorsPolicy")]
    //[Authorize]
    public class OfferingController : Controller
    {
        private readonly IOfferingService offeringService;
        public OfferingController(IOfferingService offeringService) { 
            this.offeringService = offeringService;
        }

        [HttpGet("GetRecords")]
        public IActionResult GetAllOfferingRides()
        {
            return Ok(offeringService.GetAllOfferingRides());
        }

        [HttpGet("GetRidesHistory")]
        public IActionResult GetAllOfferedRidesHistoryForUser(string email)
        {
            return Ok(offeringService.GetAllOfferedRidesHistoryForUser(email));
        }

        [HttpGet("SearchRides")]
        public IActionResult SearchOfferingRides(string email, string source, string destination)
        {
            return Ok(offeringService.SearchOfferingRides(email, source, destination));
        }

        [HttpPost("AddRides")]
        public IActionResult AddOfferingRides(string email, OfferingRides offeringRides)
        {
            return Ok(offeringService.AddOfferingRides(email, offeringRides));
        }
    }
}
