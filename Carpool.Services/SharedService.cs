using Carpool.DataStorage;
using Carpool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class SharedService : ISharedService
    {
        public readonly CarpoolContext context;

        public SharedService(CarpoolContext _context) 
        {
            this.context= _context;
        }
        public int GetUserId(string email)
        {
            User user = context.Users.Where(u => u.EmailId == email).First<User>();

            return user.UserId;
        }
    }
}
