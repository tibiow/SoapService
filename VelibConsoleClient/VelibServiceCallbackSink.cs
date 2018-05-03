using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsClient
{
    class VelibServiceCallbackSink : VelibConsoleClient.VelibService.IService1Callback
    {
        public void AvailableBikes(int number)
        {
            Console.WriteLine("new number of bikes available " + number);
        }
    }
}

