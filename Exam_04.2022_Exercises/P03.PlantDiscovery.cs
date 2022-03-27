using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.PlantDiscovery
{
    class Plant
    {
        public Plant(string namePlant, int rarity, double rate)
        {
            this.NamePlant = namePlant;
            this.Rarity = rarity;
            this.Rate = rate;
        }

        public string NamePlant { get; set; }

        public int Rarity { get; set; }

        public double Rate { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plantList = new List<Plant>();
            int numberLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberLines; i++)
            {
                string data = Console.ReadLine();
                string[] command = data
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string namePlant = command[0];
                int rarity = int.Parse(command[1]);

                if (plantList.Any(x => x.NamePlant == namePlant))
                {
                    foreach (Plant item in plantList)
                    {
                        if (item.NamePlant == namePlant)
                        {
                            item.Rarity = rarity;
                        }
                    }
                }
                else
                {
                    Plant currentPlant = new Plant(namePlant, rarity, 0);
                    plantList.Add(currentPlant);
                }
            }

            string commandLine = Console.ReadLine();
            while (commandLine != "Exhibition")
            {
                string[] commandArray = commandLine
                    .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string cmdPrime = commandArray[0];
                string[] commandArraySub = commandArray[1]
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (cmdPrime == "Rate")
                {
                    string plant = commandArraySub[0];
                    double rating = double.Parse(commandArraySub[1]);

                    if (!plantList.Any(x => x.NamePlant == plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        foreach (Plant item in plantList)
                        {
                            if (item.NamePlant == plant)
                            {
                                if (item.Rate == 0)
                                {
                                    item.Rate = rating;
                                }
                                else
                                {
                                    item.Rate = (item.Rate + rating) / 2;
                                }
                            }
                        }
                    }
                }
                else if (cmdPrime == "Update")
                {
                    string plant = commandArraySub[0];
                    int newRarity = int.Parse(commandArraySub[1]);

                    if (!plantList.Any(x => x.NamePlant == plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        foreach (Plant item in plantList)
                        {
                            if (item.NamePlant == plant)
                            {
                                item.Rarity = newRarity;
                            }
                        }
                    }
                }
                else if (cmdPrime == "Reset")
                {
                    string plant = commandArraySub[0];

                    if (!plantList.Any(x => x.NamePlant == plant))
                    {
                        Console.WriteLine("error");
                    }
                    else
                    {
                        foreach (Plant item in plantList)
                        {
                            if (item.NamePlant == plant)
                            {
                                item.Rate = 0;
                            }
                        }
                    }
                }

                commandLine = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (Plant item in plantList)
            {
                Console.WriteLine($"- {item.NamePlant}; Rarity: {item.Rarity}; Rating: {item.Rate:f2}");
            }
        }
    }
}
