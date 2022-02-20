using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace P03.TheAngryCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string typeItem = Console.ReadLine();

            if (typeItem == "cheap")
            {
                 long sumLeft = 0;
                long sumRight = 0;

                for (int i = 0; i < entryPoint; i++)
                {
                    
                    sumLeft += inputNumbers[i];                
                }
                for (int i = entryPoint + 1; i < inputNumbers.Count; i++)
                {
                    sumRight += inputNumbers[i];
                }

                if (sumLeft <= sumRight)
                {
                    string position = "Left";
                    int minNumbers = int.MaxValue;

                    for (int i = 0; i < entryPoint; i++)
                    {
                        if (inputNumbers[i] < minNumbers)
                        {
                            minNumbers = inputNumbers[i];
                        }
                    }

                    Console.WriteLine($"{position} - {minNumbers}");
                }
                else
                {
                    string position = "Right";
                    int minNumbers = int.MaxValue;

                    for (int i = entryPoint + 1; i < inputNumbers.Count; i++)
                    {
                        if (inputNumbers[i] < minNumbers)
                        {
                            minNumbers = inputNumbers[i];
                        }
                    }

                    Console.WriteLine($"{position} - {minNumbers}");
                }


            }
            else if (typeItem == "expensive")
            {
                long sumLeft = 0;
                long sumRight = 0;

                for (int i = 0; i < entryPoint; i++)
                {
                    sumLeft += inputNumbers[i];
                }

                for (int i = entryPoint + 1; i < inputNumbers.Count; i++)
                {
                    sumRight += inputNumbers[i];
                }

                if (sumLeft >= sumRight)
                {
                    string position = "Left";
                    Console.WriteLine($"{position} - {sumLeft}");                        
                }
                else
                {
                    string position = "Right";
                    Console.WriteLine($"{position} - {sumRight}");
                }

            }

        }
    }
}
