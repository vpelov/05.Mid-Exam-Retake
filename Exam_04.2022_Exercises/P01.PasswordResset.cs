using System;
using System.Linq;

namespace P01.PasswordResset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string inputData = Console.ReadLine();
            string newText = string.Empty;

            while (inputData != "Done")
            {
                string[] commandArray = inputData
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArray[0];

                if (command == "TakeOdd")
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            newText += text[i];
                        }
                    }
                    Console.WriteLine(newText);
                    inputData = Console.ReadLine();
                    continue;
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(commandArray[1]);
                    int lenght = int.Parse(commandArray[2]);
                    newText = newText.Remove(index, lenght);
                    Console.WriteLine(newText);
                    inputData = Console.ReadLine();
                    continue;
                }
                else if (command == "Substitute")
                {
                    string substring = commandArray[1];
                    string substitute= commandArray[2];

                    if (!newText.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        inputData = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        newText = newText.Replace(substring, substitute);
                        inputData = Console.ReadLine();
                        continue;
                    }
                }
            }

            Console.WriteLine($"Your password is: {newText}");

        }
    }
}
