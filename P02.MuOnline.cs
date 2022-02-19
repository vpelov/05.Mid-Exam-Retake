using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputSrting = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            int health = 100;
            int bitcoins = 0;
            int room = 0;
            bool isLive = true;

            int length = inputSrting.Count;

            for (int i = 0; i < length; i++)
            {
                room++;
                string[] command = inputSrting[i].Split().ToArray();
                string currentCommand = command[0];
                int currentValue = int.Parse(command[1]);

                if (currentCommand == "potion")
                {

                    health += currentValue;
                    if (health > 100)
                    {
                        int divide = 100 - (health - currentValue);
                        health = 100;

                        Console.WriteLine($"You healed for {divide} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {currentValue} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        continue;
                    }


                }
                if (currentCommand == "chest")
                {
                    Console.WriteLine($"You found {currentValue} bitcoins.");
                    bitcoins += currentValue;
                    continue;
                }

                health -= currentValue;

                if (health > 0)
                {
                    Console.WriteLine($"You slayed {currentCommand}.");
                }
                else if (health <= 0)
                {
                    Console.WriteLine($"You died! Killed by {currentCommand}.");
                    Console.WriteLine($"Best room: {room}");
                    isLive = false;
                    break;
                }


            }

            if (isLive)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }

    }
}
    

