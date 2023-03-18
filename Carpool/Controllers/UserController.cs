using Carpool.DataStorage;
using Carpool.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Carpool.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [EnableCors("devCorsPolicy")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService,IConfiguration configuration)
        {
            this.userService = userService;
            this._configuration = configuration;
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
            var res = userService.LoginUser(user);
            if (!res)
            {
                return NotFound(res);
            }

            var authClaims = new List<Claim>
            {
                new Claim("email",user.EmailId),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            //return Ok("Yes");
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
