using Carpool.DataStorage;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [EnableCors("devCorsPolicy")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(User user)
        {
            var res = userService.CreateUser(user);
            if (!res)
            {
                return Conflict(res);
            }
            return Ok(res);
            //return Ok("yes");
        }

        [HttpPost("LoginUser")]
        public IActionResult LoginUser(User user)
        {
            var res=userService.LoginUser(user);
            if (!res)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(string email)
        {
            var res = userService.DeleteUser(email);
            if (!res)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [HttpGet("GetAllUser")]
        public IActionResult GetAllUser()
        {
            return Ok(userService.GetAllUser());
        }
    }
}
