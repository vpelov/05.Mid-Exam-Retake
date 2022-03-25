using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            int threshold = 1;

            char[] charArray = inputData.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsDigit(charArray[i]))
                {
                    threshold *= int.Parse(charArray[i].ToString());
                }
            }
            Dictionary<string, int> result = new Dictionary<string, int>();
            int count = 0;
            string pattern = @"([:|*]{2})[A-Z]{1}[a-z]{2,}\1";

            MatchCollection match = Regex.Matches(inputData, pattern);

            foreach (Match item in match)
            {
                string currentString = item.ToString();
                char[] currentArray = currentString.ToCharArray();
                int curentCount = 0;
                count++;
                for (int j = 2; j < currentArray.Length - 2; j++)
                {
                    curentCount += currentArray[j];
                }

                if (curentCount >= threshold)
                {
                    result.Add(currentString, curentCount);
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }

        }
    }
}
