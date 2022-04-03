using System;
using System.Linq;

namespace P01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Abracadabra")
            {
                string[] cmdArr = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmdArr[0] == "Abjuration")
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }
                else if (cmdArr[0] == "Necromancy")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (cmdArr[0] == "Illusion")
                {
                    int index = int.Parse(cmdArr[1]);
                    string letter = cmdArr[2];
                    if (index < 0 || index > text.Length - 1)
                    {
                        Console.WriteLine("The spell was too weak.");
                    }
                    else
                    {
                        text = text.Remove(index, 1);
                        text = text.Insert(index, letter);
                        Console.WriteLine("Done!");
                    }

                }
                else if (cmdArr[0] == "Divination")
                {
                    string subStringOne = cmdArr[1];
                    string subStringTwo = cmdArr[2];
                    if (!text.Contains(subStringOne))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        text = text.Replace(subStringOne, subStringTwo);
                        Console.WriteLine(text);
                    }
                }
                else if (cmdArr[0] == "Alteration")
                {
                    string subString = cmdArr[1];
                    if (!text.Contains(subString))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        while (text.Contains(subString))
                        {
                            int index = text.IndexOf(subString);
                            text = text.Remove(index, subString.Length);
                        }
                        Console.WriteLine(text);
                    }
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }

                command = Console.ReadLine();
            }

        }
    }
}