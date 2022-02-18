using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split().ToList();
            string digits = Console.ReadLine();

            bool isWin = true;

            int count = 1;

            while (digits != "end")
            {
                List<int> indexes = digits.Split().Select(int.Parse).ToList();
                int indexOne = indexes[0];
                int indexTwo = indexes[1];

                if (indexOne == indexTwo || indexOne >= numbers.Count || indexOne < 0 || indexTwo >= numbers.Count || indexTwo < 0)
                {
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                    int middleIndex = (numbers.Count / 2);
                    string element = "-" + count.ToString() + "a";
                    numbers.Insert(middleIndex, element);
                    numbers.Insert(middleIndex, element);

                }
                else if (numbers[indexOne] == numbers[indexTwo])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {numbers[indexOne]}!");
                    if (indexOne > indexTwo)
                    {
                        numbers.RemoveAt(indexOne);
                        numbers.RemoveAt(indexTwo);
                    }
                    else
                    {
                        numbers.RemoveAt(indexTwo);
                        numbers.RemoveAt(indexOne);
                    }
                }
                else if (numbers[indexOne] != numbers[indexTwo])
                {
                    Console.WriteLine("Try again!");
                }




                if (numbers.Count == 0)
                {
                    Console.WriteLine($"You have won in {count} turns!");
                    isWin = false;
                    break;
                }

                count++;
                digits = Console.ReadLine();
            }

            if (isWin)
            {
                Console.WriteLine($"Sorry you lose :( ");
                Console.WriteLine(String.Join(" ", numbers));
            }

        }       


    }
}
