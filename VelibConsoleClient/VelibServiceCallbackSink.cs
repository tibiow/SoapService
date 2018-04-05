using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsClient
{
    class VelibServiceCallbackSink : VelibConsoleClient.VelibService.IService1Callback
    {
        public void AvailableBikes(string city, string station, int number)
        {
            Console.WriteLine("Available completed");
        }

        public void AvailableBikesFinished()
        {
            Console.WriteLine("Available completed");
        }
    }
}

