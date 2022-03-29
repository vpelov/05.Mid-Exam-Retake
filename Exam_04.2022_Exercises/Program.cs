using System;
using System.Linq;

namespace P01.PasswordReset2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Done")
                {
                    break;
                }
                string[] commandArr = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string firstCommand = commandArr[0];

                if (firstCommand == "TakeOdd")
                {
                    password = string.Concat(password.Where((item, index) => index % 2 != 0));
                    Console.WriteLine(password);
                }
                else if (firstCommand == "Cut")
                {
                    int index = int.Parse(commandArr[1]);
                    int lenght = int.Parse(commandArr[2]);

                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else if (firstCommand == "Substitute")
                {
                    string subString = commandArr[1];
                    string substitute = commandArr[2];

                    if (!password.Contains(subString))
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                    else
                    {
                        password = password.Replace(subString, substitute);
                        Console.WriteLine(password);
                    }
                }
            }

                Console.WriteLine($"Your password is: {password}");

        }
    }
}
