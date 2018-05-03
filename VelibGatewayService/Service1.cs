using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Timers;

namespace VelibGatewayService
{


    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1
    {

        ObjectCache cache = MemoryCache.Default;
        static Action<int> bikeUpdate = delegate { };
        private List<StationToUpdate> stations = new List<StationToUpdate>();

        private Timer timer = new Timer();

        public Service1()
        {
            timer.Elapsed += RefreshTimerElapsed;
            timer.Interval = 10000; // 10 seconds
            timer.Start();
        }

        private void RefreshTimerElapsed(object sender, ElapsedEventArgs e)
        {
            
            foreach (StationToUpdate s in stations)
            {
                int BikesAvailaible =  GetBikes(s.City, s.Station);
                bikeUpdate(BikesAvailaible);
            }
            
        }

        public void SubscribeToStation(string city, string station)
        {
            Console.WriteLine("new sub");
            IService1Events sub = OperationContext.Current.GetCallbackChannel<IService1Events>();
            stations.Add(new StationToUpdate(city, station));
            bikeUpdate += sub.AvailableBikes;
        }

        public int GetBikes(string city, string station)
        {
            string responseFromServer = GetRestApiResult("https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
            //convert the server answer into a List of station
            List<Station> stationsList = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

            foreach (Station s in stationsList)
            {
                if (s.Name.Equals(station))
                {
                    return s.Available_bikes;
                }
            }

            return -1;
        }

        public async Task<string[]> GetAllCity()
        {
            return (await GetAllCityAsync());
        }

        public async Task<string[]> GetAllCityAsync()
        {
            //permet de refresh la liste toutes les 10 heures.
            DateTimeOffset time = DateTimeOffset.Now.AddHours(10.0);


            if (!cache.Contains("cities"))
            {

                string responseFromServer = await GetRestApiResultAsync("https://api.jcdecaux.com/vls/v1/contracts?&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");

                List<Contract> contractList = JsonConvert.DeserializeObject<List<Contract>>(responseFromServer);
                string[] reponse = new string[contractList.Count];
                for (int i = 0; i < contractList.Count; i++)
                {
                    reponse[i] = contractList.ElementAt(i).Name;
                }
                cache.Add("cities", reponse, time);
                return reponse;
            }
            else
            {
                return (string[])cache.Get("cities");
            }
        }

        public async Task<string[]> GetAllStations(string contract)
        {
            return (await GetAllStationsAsync(contract));
        }

        public async Task<string[]> GetAllStationsAsync(string contract)
        {
            //dans le cas où le contrat n'est pas stipulé je met contrat à Toulouse pour éviter tout crash de l'application
            if (contract == "")
                contract = "Toulouse";

            //permet de refresh la liste toutes les 5 minutes.
            DateTimeOffset time = DateTimeOffset.Now.AddMinutes(5.0);

            if (!cache.Contains(contract))
            {
                string responseFromServer = await GetRestApiResultAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
                //convert the server answer into a List of station
                List<Station> stationsList = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

                //string jsonString = stationsList.ToJSON();
                string[] reponse = new string[stationsList.Count];
                for (int i = 0; i < stationsList.Count; i++)
                {
                    reponse[i] = stationsList.ElementAt(i).Name;
                }
                cache.Add(contract, reponse, time);
                return reponse;
            }
            else
            {
                return (string[])cache.Get(contract);
            }



        }

        public async Task<int> GetAvailableBike(string contract, string station)
        {
            return await Task.Run(() => GetAvailableBikeAsync(contract,station));
        }

        public async Task<int> GetAvailableBikeAsync(string contract, string station)
        {

            //permet de refresh la liste toutes les 5 minutes
            DateTimeOffset time = DateTimeOffset.Now.AddMinutes(5.0);

            if (!cache.Contains(station))
            {

                
                string responseFromServer = await GetRestApiResultAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
                //convert the server answer into a List of station
                List<Station> stationsList = JsonConvert.DeserializeObject<List<Station>>(responseFromServer);

                foreach (Station s in stationsList)
                {
                    if (s.Name.Equals(station))
                    {
                        cache.Add(station, s.Available_bikes, time);
                        return s.Available_bikes;
                    }
                }

                return -1;
            }
            else
            {
                return (int)cache.Get(station);
            }

        }

        public string GetRestApiResult(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.

            return reader.ReadToEnd();
        }

        public async Task<string> GetRestApiResultAsync(string url)
        {
            var myTask = Task.Factory.StartNew(() => GetRestApiResult(url));
            var result = await myTask;
            return result;
        }

        public async void Available(string city,string station)
        {
            int number = await GetAvailableBike(city, station);
            bikeUpdate(number);
        }


    }

    
}
