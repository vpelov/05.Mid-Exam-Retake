using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.FriendListMaintence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> nameList = Console.ReadLine().Split(", ").ToList();

            int lostCount = 0;
            int blackListCount = 0;

            string command = Console.ReadLine();

            while (command != "Report")
            {
                string[] commandArray = command.Split().ToArray();

                if (commandArray[0] == "Blacklist")
                {
                    if (nameList.Contains(commandArray[1]))
                    {
                        Console.WriteLine($"{commandArray[1]} was blacklisted.");
                        blackListCount++;
                        for (int i = 0; i < nameList.Count; i++)
                        {
                            if (nameList[i] == commandArray[1])
                            {
                                nameList[i] = "Blacklisted";
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{commandArray[1]} was not found.");
                    }


                }
                else if (commandArray[0] == "Error")
                {
                    int index = int.Parse(commandArray[1]);
                    if (index >= 0 && index < nameList.Count && nameList[index] != "Blacklisted" && nameList[index] != "Lost" )
                    {
                        Console.WriteLine($"{nameList[index]} was lost due to an error.");
                        lostCount++;
                        nameList[index] = "Lost";
                    }
                }
                else if (commandArray[0] == "Change")
                {
                    int index = int.Parse(commandArray[1]);
                    string newName = commandArray[2];

                    if (index >= 0 && index < nameList.Count)
                    {
                        Console.WriteLine($"{nameList[index]} changed his username to {newName}.");
                        nameList[index] = newName;
                    }


                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blackListCount} ");
            Console.WriteLine($"Lost names: {lostCount}");
            Console.WriteLine(string.Join(" ", nameList));

        }
    }
}
