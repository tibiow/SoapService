using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsClient
{
    class VelibServiceCallbackSink : VelibConsoleClient.VelibService.IService1Callback
    {
        string name_of_client;
        public VelibServiceCallbackSink(string name)
        {
            name_of_client = name;
        }
        public void AvailableBikes(int number)
        {
            Console.WriteLine(name_of_client + " : new number of bikes available " + number);
        }
    }
}

