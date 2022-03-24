using System;
using System.Linq;

namespace P01.SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string inputData = Console.ReadLine();

            while (inputData != "Reveal")
            {
                string[] commandArray = inputData
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                string command =commandArray[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(commandArray[1]);
                    message = message.Insert(index, " ");
                    Console.WriteLine(message);

                }
                else if (command == "Reverse")
                {
                    string substring = commandArray[1];
                    int indexSubstr = message.IndexOf(substring);

                    if (indexSubstr == -1)
                    {
                        Console.WriteLine("error");
                        inputData = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        message = message.Remove(indexSubstr, substring.Length);
                        message = message + string.Join("", substring.Reverse());
                        Console.WriteLine(message);
                        inputData = Console.ReadLine();
                        continue;
                    }

                }
                else if (command == "ChangeAll")
                {
                    string substring = commandArray[1];
                    string replacment = commandArray[2];

                    message = message.Replace(substring, replacment);
                    Console.WriteLine(message);
                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");

        }
    }
}
