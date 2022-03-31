using System;
using System.Linq;

namespace P01.ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            while (true)
            {
                string[] commandArr = Console.ReadLine()
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArr[0];

                if (command == "Contains")
                {
                    string subString = commandArr[1];
                    if (key.Contains(subString))
                    {
                        Console.WriteLine($"{key} contains {subString}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }

                }
                else if (command == "Flip")
                {
                    string upLower = commandArr[1];
                    int startIndex = int.Parse(commandArr[2]);
                    int endIndex = int.Parse(commandArr[3]);

                    if (upLower == "Upper")
                    {
                        string current = key.Substring(startIndex, endIndex - startIndex).ToUpper();
                        key = key.Remove(startIndex, endIndex - startIndex);
                        key = key.Insert(startIndex, current);
                        Console.WriteLine(key);
                    }
                    else if (upLower == "Lower")
                    {
                        string current = key.Substring(startIndex, endIndex - startIndex).ToLower();
                        key = key.Remove(startIndex, endIndex - startIndex);
                        key = key.Insert(startIndex, current);
                        Console.WriteLine(key);
                    }

                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(commandArr[1]);
                    int endIndex = int.Parse(commandArr[2]);

                    key = key.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(key);

                }
                else if (command == "Generate")
                {
                    break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}");

        }
    }
}
