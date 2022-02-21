using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumber = Console.ReadLine().Split().Select(int.Parse).ToList();
            double sumLeft = GetLeftSum(inputNumber);
            double sumRight= GetRightSum(inputNumber);

            if (sumLeft < sumRight)
            {
                Console.WriteLine($"The winner is left with total time: {sumLeft}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {sumRight}");
            }
        }

        static double GetLeftSum(List<int> inputNumber)
        {
            double sum = 0;
            int middleIndex = inputNumber.Count / 2;

            for (int i = 0; i < middleIndex; i++)
            {
                sum += inputNumber[i];
                if (inputNumber[i] == 0)
                {
                    sum *= 0.8;
                }
            }
            return sum;
        }

        static double GetRightSum(List<int> inputNumber)
        {

            double sum = 0;
            int middleIndex = inputNumber.Count / 2;

            for (int i = middleIndex + 1; i < inputNumber.Count; i++)
            {
                sum += inputNumber[i];
                if (inputNumber[i] == 0)
                {
                    sum *= 0.8;
                }
            }
            return sum;
        }

    }
}
