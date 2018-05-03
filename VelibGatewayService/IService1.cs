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
    [ServiceContract(CallbackContract = typeof(IService1Events))]
    public interface IService1
    {
        [OperationContract]
        Task<string[]> GetAllCity();

        [OperationContract]
        Task<string[]> GetAllStations(string contract);

        [OperationContract]
        Task<int> GetAvailableBike(string contract, string station);

        [OperationContract]
        void Available(string city,string contrat);

        [OperationContract]
        void SubscribeToStation(string city, string station);



    }

    
}
