using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibGatewayService
{
    class Contract
    {
        public string Name { get; set; }
        public List<string> Cities { get; set; }
        public string Commercial_name { get; set; }
        public string Country_code { get; set; }
    }
}
