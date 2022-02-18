using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MovingTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumber = Console.ReadLine().Split().Select(int.Parse).ToList();
           
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] commandArray = command.Split();
                int index = int.Parse(commandArray[1]);

                switch (commandArray[0])
                {
                    case "Shoot":
                        int power = int.Parse(commandArray[2]);
                        if (index >= 0 && index < inputNumber.Count)
                        {
                            if (inputNumber[index] > power)
                            {
                                inputNumber[index] -= power;
                            }
                            else
                            {
                                inputNumber.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":
                        int value = int.Parse(commandArray[2]);
                        if (index >= 0 && index < inputNumber.Count)
                        {
                            inputNumber.Insert(index, value);
                            
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;

                    case "Strike":
                        int radius = int.Parse(commandArray[2]);
                        int startIndex = index - radius;
                        int endIndex = index + radius;

                        if (startIndex >= 0 && endIndex < inputNumber.Count - 1)
                        {
                            inputNumber.RemoveRange(startIndex, (radius * 2) + 1);
                        }
                        else
                        {
                            Console.WriteLine("Strike missed!");
                        }

                        break;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(String.Join("|", inputNumber));


        }
    }
}
