using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelibConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibService.Service1Client client = new VelibService.Service1Client();

            while (true)
            {
                Console.Write("si vous souhaitez la liste des contrats, entrez \"contrat\" \n" +
                "si vous souhaitez la liste des stations, entrez  \"list\" \n" +
                "si vous souhaitez connaitre le nombre de vélo disponible à une station, entrez  \"bike\" : \n");
                var argument = Console.ReadLine();
                switch (argument)
                {
                    case "contrat":
                        string[] ListOfContract = client.GetAllCity();
                        for (int i = 0; i < ListOfContract.Length; i++)
                        {
                            Console.WriteLine(ListOfContract[i]);
                        }
                        break;
                    case "list":
                        Console.WriteLine("veuillez spécifier le contract :");
                        var contrat = Console.ReadLine();
                        string[] ListOfStation = client.GetAllStations(contrat);
                        for (int i = 0; i < ListOfStation.Length; i++)
                        {
                            Console.WriteLine(ListOfStation[i]);
                        }
                        break;
                    case "bike":
                        Console.WriteLine("veuillez spcifier le contract :");
                        var contract = Console.ReadLine();
                        Console.WriteLine("veuillez spécifier la station :");
                        var station = Console.ReadLine();
                        Console.WriteLine("Nombre de vélos libres : " + client.GetAvailableBike(contract,station) );
                        break;

                }

            }
        }
    }
}
