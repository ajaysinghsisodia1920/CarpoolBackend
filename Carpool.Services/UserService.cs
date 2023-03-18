//using Carpool.Model;
using Carpool.DataStorage;
using Carpool.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services
{
    public class UserService : IUserService
    {

        private readonly CarpoolContext context;

        public UserService(CarpoolContext _context)
        {
            this.context = _context;
        }

        public bool CreateUser(User user)
        {
            var result = context.Users.Where(u => u.EmailId == user.EmailId).FirstOrDefault();
            if (result != null)
            {
                return false;
            }
            user.Username = user.EmailId.Split('@')[0];
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool LoginUser(User user)
        {
            var result = context.Users.Where(u => u.EmailId == user.EmailId && u.Password == user.Password).FirstOrDefault();
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(string email)
        {
            var result = context.Users.Where(u => u.EmailId == email).FirstOrDefault();
            if (result == null)
            {
                return false;
            }

            context.Users.Remove(result);
            context.SaveChanges();
            return true;

        }

        public List<User> GetAllUser()
        {
            return context.Users.ToList();
        }

    }
}
