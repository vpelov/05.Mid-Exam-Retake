using System;

namespace P01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double total = 0;

            while (command != "special" && command != "regular")
            {
                double currentprise = double.Parse(command);
                if (currentprise < 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                total += currentprise;
                }

                command = Console.ReadLine();   
            }

            if (total == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                if (command == "special")
                {
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {total:f2}$");
                    Console.WriteLine($"Taxes: {total * 0.2:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {(total + (total * 0.2)) * 0.9:f2}$");
                }
                if (command == "regular")
                {
                    Console.WriteLine("Congratulations you've just bought a new computer!");
                    Console.WriteLine($"Price without taxes: {total:f2}$");
                    Console.WriteLine($"Taxes: {total * 0.2:f2}$");
                    Console.WriteLine("-----------");
                    Console.WriteLine($"Total price: {total + (total * 0.2):f2}$");
                }

            }

        }
    }
}
