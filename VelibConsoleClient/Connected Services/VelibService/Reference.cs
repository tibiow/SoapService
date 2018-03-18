﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelibConsoleClient.VelibService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCity", ReplyAction="http://tempuri.org/IService1/GetAllCityResponse")]
        string[] GetAllCity();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCity", ReplyAction="http://tempuri.org/IService1/GetAllCityResponse")]
        System.Threading.Tasks.Task<string[]> GetAllCityAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStations", ReplyAction="http://tempuri.org/IService1/GetAllStationsResponse")]
        string[] GetAllStations(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStations", ReplyAction="http://tempuri.org/IService1/GetAllStationsResponse")]
        System.Threading.Tasks.Task<string[]> GetAllStationsAsync(string contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAvailableBike", ReplyAction="http://tempuri.org/IService1/GetAvailableBikeResponse")]
        int GetAvailableBike(string contract, string station);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAvailableBike", ReplyAction="http://tempuri.org/IService1/GetAvailableBikeResponse")]
        System.Threading.Tasks.Task<int> GetAvailableBikeAsync(string contract, string station);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : VelibConsoleClient.VelibService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<VelibConsoleClient.VelibService.IService1>, VelibConsoleClient.VelibService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetAllCity() {
            return base.Channel.GetAllCity();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllCityAsync() {
            return base.Channel.GetAllCityAsync();
        }
        
        public string[] GetAllStations(string contract) {
            return base.Channel.GetAllStations(contract);
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllStationsAsync(string contract) {
            return base.Channel.GetAllStationsAsync(contract);
        }
        
        public int GetAvailableBike(string contract, string station) {
            return base.Channel.GetAvailableBike(contract, station);
        }
        
        public System.Threading.Tasks.Task<int> GetAvailableBikeAsync(string contract, string station) {
            return base.Channel.GetAvailableBikeAsync(contract, station);
        }
    }
}