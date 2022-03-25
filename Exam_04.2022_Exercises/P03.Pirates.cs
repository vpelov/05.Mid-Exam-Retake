using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Pirates
{
    class City
    {
        public City(string town,int population, int gold)
        {
            this.Town = town;
            this.Population = population;
            this.Gold = gold;
        }

        public string Town{ get; set; }

        public int Population { get; set; }

        public int Gold { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> cityDict = new Dictionary<string, City>();

            string data = Console.ReadLine();

            while (data != "Sail")
            {
                string[] command = data
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string city = command[0];
                int population = int.Parse(command[1]);
                int gold= int.Parse(command[2]);

                City currentCity = new City(city, population, gold);

                if (cityDict.ContainsKey(city))
                {
                    cityDict[city].Population += population;
                    cityDict[city].Gold += gold;
                }
                else
                {
                    cityDict.Add(city, currentCity);
                }
                data = Console.ReadLine();
            }

            string atack = Console.ReadLine();

            while (atack != "End")
            {
                string[] commandArray = atack
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (commandArray[0] == "Plunder")
                {
                    string town = commandArray[1];
                    int people = int.Parse(commandArray[2]);
                    int gold = int.Parse(commandArray[3]);

                    if (cityDict[town].Population - people <= 0 || cityDict[town].Gold - gold <= 0)
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        Console.WriteLine($"{town} has been wiped off the map!");
                        cityDict.Remove(town);
                        atack = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        cityDict[town].Population -= people;
                        cityDict[town].Gold -= gold;
                        atack = Console.ReadLine();
                        continue;
                    }

                }
                else if (commandArray[0] == "Prosper")
                {
                    string town = commandArray[1];
                    int gold = int.Parse(commandArray[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        atack = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        cityDict[town].Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cityDict[town].Gold} gold.");
                        atack = Console.ReadLine();
                        continue;
                    }

                }
                atack = Console.ReadLine();
            }

            Console.WriteLine($"Ahoy, Captain! There are {cityDict.Count} wealthy settlements to go to:");

            foreach (var item in cityDict)
            {
                Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
            }

        }
    }
}
