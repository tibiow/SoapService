using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VelibGatewayService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<string[]> GetAllCity();

        [OperationContract]
        Task<string[]> GetAllStations(string contract);

        [OperationContract]
        Task<int> GetAvailableBike(string contract, string station);

    }

    
}
