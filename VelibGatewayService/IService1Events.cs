using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VelibGatewayService
{
    interface IService1Events
    {
        [OperationContract(IsOneWay = true)]
        void AvailableBikes(string city,string station,int number);

        [OperationContract(IsOneWay = true)]
        void AvailableBikesFinished();
    }
}
