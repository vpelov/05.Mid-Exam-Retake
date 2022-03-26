using System;
using System.Linq;

namespace P01.TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string inputData = Console.ReadLine();

            while (inputData != "Decode")
            {
                string[] cmdArray = inputData
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = cmdArray[0];

                if (command == "Move")
                {
                    int numberLetters = int.Parse(cmdArray[1]);
                    string currentStr = message.Substring(0, numberLetters);
                    message = message.Remove(0, numberLetters);
                    message = message + currentStr;
                    Console.WriteLine(message);

                }
                else if (command == "Insert")
                {
                    int index = int.Parse(cmdArray[1]);
                    string newString = cmdArray[2];
                    message = message.Insert(index, newString);
                }
                else if (command == "ChangeAll")
                {
                    string substring = cmdArray[1];
                    string stringReplacment = cmdArray[2];
                    message = message.Replace(substring, stringReplacment);

                }

                inputData = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");


        }
    }
}
