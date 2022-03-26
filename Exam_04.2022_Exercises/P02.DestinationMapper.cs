using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)([A-Z]{1}[A-Za-z]{2,})(\1)";
            List<string> travelPoint = new List<string>();
            int countAllLenght = 0;

            string travelData = Console.ReadLine();
            MatchCollection match = Regex.Matches(travelData, pattern);

            foreach (Match item in match)
            {
                string current = item.Value;
                current = current.Remove(0, 1);
                current = current.Remove(current.Length - 1, 1);
                countAllLenght += current.Length;

                travelPoint.Add(current);
            }

            Console.Write("Destinations: ");

            Console.Write(String.Join(", ", travelPoint));
            Console.WriteLine();
            Console.WriteLine($"Travel Points: {countAllLenght}");

        }
    }
}
