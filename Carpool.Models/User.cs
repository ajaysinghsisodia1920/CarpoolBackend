using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.DataStorage
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string EmailId { get; set; }

        public string Username { get; set; }    

        public string Password { get; set; }

        //List<BookedRides> BookedRides { get; set; }

    }
}
