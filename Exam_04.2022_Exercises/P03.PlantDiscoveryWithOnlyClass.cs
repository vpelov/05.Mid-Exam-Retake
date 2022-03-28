using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PlantDiscoveryWithOnlyClass
{
    class Plant
    {
        public Plant(string plantName, int rarity)
        {
            this.PlantName = plantName;
            this.Rarity = rarity;
            this.Rate = new List<double>();
        }

        public string PlantName { get; set; }

        public int Rarity { get; set; }

        public List<double> Rate { get; set; }


        public void AddRate(double rate)
        {
            this.Rate.Add(rate);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plantList = new List<Plant>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string plantName = command[0];
                int rarity = int.Parse(command[1]);

                if (plantList.Any(p => p.PlantName == plantName))
                {
                    Plant currentPlant = plantList.FirstOrDefault(p => p.PlantName == plantName);
                    currentPlant.Rarity = rarity;
                }
                else
                {
                    Plant newPlant = new Plant(plantName, rarity);
                    plantList.Add(newPlant);
                }
            }

            string commands = Console.ReadLine();
            while (commands != "Exhibition")
            {
                string[] commandArray = commands
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmd = commandArray[0];
                string[] cmdArrays = commandArray[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (cmd == "Rate")
                {
                    string plant = cmdArrays[0];
                    double rating = double.Parse(cmdArrays[1]);
                    if (!plantList.Any(p => p.PlantName == plant))
                    {
                        Console.WriteLine("error");                        
                    }
                    else
                    {
                        Plant current = plantList.First(p => p.PlantName == plant);
                        current.AddRate(rating);         // Metod in class. That is work
                        //current.Rate.Add(rating);      // Without metod in class. And that is work :)
                    }
                }
                else if (cmd == "Update")
                {
                    string plant = cmdArrays[0];
                    int rarity = int.Parse(cmdArrays[1]);
                    if (!plantList.Any(x => x.PlantName == plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        UpdateRarity(plantList, plant, rarity);
                    }

                }
                else if (cmd == "Reset")
                {
                    string plant = cmdArrays[0];

                    if (!plantList.Any(x => x.PlantName == plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        Plant current = plantList.First(x => x.PlantName == plant);

                        for (int i = current.Rate.Count - 1; i >= 0; i--)
                        {
                            current.Rate.Remove(current.Rate[i]);
                        }                        
                    }
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant item in plantList)
            {
                double average = item.Rate.Count;
                if (average == 0)
                {
                    average = 0.00;
                }
                else
                {
                    average = item.Rate.Average();
                }
                Console.WriteLine($"- {item.PlantName}; Rarity: {item.Rarity}; Rating: {average:f2}");
            }
        }


        static void UpdateRarity(List<Plant> plantList, string plant, int rarity)
        {
            foreach (Plant item in plantList)
            {
                if (item.PlantName == plant)
                {
                    item.Rarity = rarity;
                }
            }
        }

    }
}
