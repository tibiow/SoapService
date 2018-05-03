using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibGatewayService
{
    class Station
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Position Position { get; set; }
        public Boolean Banking { get; set; }
        public Boolean Bonus { get; set; }
        public string Status { get; set; }
        public string Contract_name { get; set; }
        public int Bike_stands { get; set; }
        public int Available_bike_stands { get; set; }
        public int Available_bikes { get; set; }
        public long Last_update { get; set; }
    }
}
