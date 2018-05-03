using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibGatewayService
{
    class StationToUpdate
    {
        public string City { get; set; }
        public string Station { get; set; }
        
        public StationToUpdate(string city, string station)
        {
            City = city;
            Station = station;
            
        }
    }
}
