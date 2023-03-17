using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.DataStorage
{
    public class CarpoolContext:DbContext
    {
        public CarpoolContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<User> Users { get; set; }

        public DbSet<OfferingRides> Offerings { get; set; }

        public DbSet<BookedRides> BookedRides { get; set; }
    }
}
