using EventsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace VelibConsoleClient
{
    class Program
    {
        static VelibService.Service1Client client;

        static void Main(string[] args)
        {
            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();
            InstanceContext icontext = new InstanceContext(objsink);

            client = new VelibService.Service1Client(icontext);
            client.SubscribeToStation("Rouen", "05- HOTEL DE VILLE");


            Console.ReadLine();

            /*
            Console.Write("si vous souhaitez la liste des contrats, entrez \"contrat\" \n" +
                "si vous souhaitez la liste des stations, entrez  \"list\" \n" +
                "si vous souhaitez connaitre le nombre de vélo disponible à une station, entrez  \"bike\" \n" +
                "si vous souhaitez connaitre le nom des méthodes à utiliser, entrez \"help\": \n");
            while (true)
            {
                CallSOAP();
            }
            */
        }

        static async void CallSOAP()
        {

            var argument = Console.ReadLine();
            switch (argument)
            {
                case "contrat":
                    string[] ListOfContract = await client.GetAllCityAsync();
                    for (int i = 0; i < ListOfContract.Length; i++)
                    {
                        Console.WriteLine(ListOfContract[i]);
                    }
                    break;
                case "list":
                    Console.WriteLine("veuillez spécifier le contract :");
                    var contrat = Console.ReadLine();
                    string[] ListOfStation = await client.GetAllStationsAsync(contrat);
                    for (int i = 0; i < ListOfStation.Length; i++)
                    {
                        Console.WriteLine(ListOfStation[i]);
                    }
                    break;
                case "bike":
                    Console.WriteLine("veuillez spécifier le contract :");
                    var contract = Console.ReadLine();
                    Console.WriteLine("veuillez spécifier la station :");
                    var station = Console.ReadLine();
                    Console.WriteLine("Nombre de vélos libres : " + await client.GetAvailableBikeAsync(contract, station));
                    break;
                case "help":
                    Console.Write("si vous souhaitez la liste des contrats, entrez \"contrat\" \n" +
                "si vous souhaitez la liste des stations, entrez  \"list\" \n" +
                "si vous souhaitez connaitre le nombre de vélo disponible à une station, entrez  \"bike\" \n" +
                "si vous souhaitez connaitre le nom des méthodes à utiliser, entrez \"help\": \n");
                    break;

            }
        }
    }
}
