using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carpool.DataStorage
{
    public class OfferingRides
    {
        [Key]
        public int Id { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; } 

        public DateTime Date { get; set; }

        public TimeSpan TimeSpan { get; set; }

        public int UserId { get; set; } 


        public OfferingRides(string Source,string Destination) {
            this.Source= Source;
            this.Destination= Destination;
        }
    }
}
