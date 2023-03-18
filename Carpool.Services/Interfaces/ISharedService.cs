using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.Services.Interfaces
{
    public interface ISharedService
    {
        public int GetUserId(string email);

        public string GetUserName(int userId);
    }
}
