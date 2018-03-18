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


namespace VelibGatewayService
{
    

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        ObjectCache cache = MemoryCache.Default;

        public string[] GetAllCity()
        {
            //permet de refresh la liste toutes les 10 heures.
            DateTimeOffset time = DateTimeOffset.Now.AddHours(10.0);


            if (!cache.Contains("cities"))
            {
                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/contracts?&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
                WebResponse response = request.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.

                string responseFromServer = reader.ReadToEnd();


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

        public string[] GetAllStations(string contract)
        {
            //dans le cas où le contrat n'est pas stipulé je met contrat à Toulouse pour éviter tout crash de l'application
            if (contract == "")
                contract = "Toulouse";

            //permet de refresh la liste toutes les 5 minutes.
            DateTimeOffset time = DateTimeOffset.Now.AddMinutes(5.0);

            if (!cache.Contains(contract))
            {
                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
                WebResponse response = request.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.

                string responseFromServer = reader.ReadToEnd();
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

        public int GetAvailableBike(string contract, string station)
        {

            //permet de refresh la liste toutes les 5 minutes
            DateTimeOffset time = DateTimeOffset.Now.AddMinutes(5.0);

            if (!cache.Contains(station))
            {

                WebRequest request = WebRequest.Create("https://api.jcdecaux.com/vls/v1/stations?contract=" + contract + "&apiKey=d82787273621e9a85d7a277efa5512ac5b542627");
                WebResponse response = request.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.

                string responseFromServer = reader.ReadToEnd();
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
    }
}
