using Carpool.DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface IUserService
    {
        public bool CreateUser(User user);

        public bool LoginUser(User user);

        public bool DeleteUser(string email);

        public List<User> GetAllUser();
    }
}
