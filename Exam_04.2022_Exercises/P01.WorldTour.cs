using System;
using System.Linq;

namespace P01.WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string travelStop = Console.ReadLine();

            string commands = Console.ReadLine();
            while (commands != "Travel")
            {
                string[] commandArray = commands
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArray[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(commandArray[1]);
                    string text = commandArray[2];
                    if (index >= 0 && index < travelStop.Length)
                    {
                        travelStop = travelStop.Insert(index, text);
                    }
                    Console.WriteLine(travelStop);

                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commandArray[1]);
                    int endIndex = int.Parse(commandArray[2]);
                    if (startIndex >= 0 && startIndex < travelStop.Length)
                    {
                        if (endIndex >= 0 && endIndex < travelStop.Length)
                        {
                            travelStop = travelStop.Remove(startIndex, endIndex - startIndex + 1);
                        }
                    }
                    Console.WriteLine(travelStop);

                }
                else if (command == "Switch")
                {
                    string oldString = commandArray[1];
                    string newString = commandArray[2];
                    travelStop = travelStop.Replace(oldString, newString);
                    Console.WriteLine(travelStop);
                }

                commands = Console.ReadLine();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelStop}");
        }
    }
}
