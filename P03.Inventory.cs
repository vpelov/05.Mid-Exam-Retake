using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputItem = Console.ReadLine().Split(", ").ToList();
            string command = Console.ReadLine();

            while (command != "Craft!")
            {
                string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (commandArray[0])
                {
                    case "Collect":
                        int count = 0;
                        for ( int i = 0; i < inputItem.Count; i++)
                        {
                            if (inputItem[i] == commandArray[2])
                            {
                                count++;
                                break;
                            }
                        }
                        if (count == 0)
                        {
                                inputItem.Add(commandArray[2]);
                        }
                        break;

                    case "Drop":
                        for (int i = 0; i < inputItem.Count; i++)
                        {
                            if (inputItem[i] == commandArray[2])
                            {
                                inputItem.Remove(commandArray[2]);
                                break;
                            }                            
                        }
                        break;

                    case "Combine":
                        string[] currentCommand = commandArray[3].Split(":");

                        for (int i = 0; i < inputItem.Count; i++)
                        {                            
                            if (inputItem[i] == currentCommand[0])
                            {
                                inputItem.Insert(i + 1, currentCommand[1]);
                                break;
                            }
                        }                  
                        break;

                    case "Renew":
                        for (int i = 0; i < inputItem.Count; i++)
                        {
                            if (inputItem[i] == commandArray[2])
                            {
                                inputItem.Remove(commandArray[2]);
                                inputItem.Add(commandArray[2]);                               
                                break;
                            }
                        }

                        break;
                }

                command = Console.ReadLine();   
            }

            Console.WriteLine(String.Join(", ", inputItem));

        }
    }
}
