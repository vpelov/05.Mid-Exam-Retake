using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.EmojiDetectorTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputData = Console.ReadLine();
            int threshold = 1;

            char[] charArr = inputData.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (char.IsDigit(charArr[i]))
                {
                    threshold *= (int)charArr[i] - '0';
                }
            }

            string pattern = @"([::]{2}|[**]{2})[A-Z]{1}[a-z]{2,}(\1)";
            MatchCollection match = Regex.Matches(inputData, pattern);
            List<string> dataList = new List<string>();

            foreach (var item in match)
            {
                char[] currentChar = item.ToString().ToCharArray();
                int totalNumber = 0;
                for (int i = 2; i < currentChar.Length - 2; i++)
                {
                    int number = (int)currentChar[i];
                    totalNumber += number;
                }
                string name = item.ToString();
                if (totalNumber >= threshold)
                {
                    dataList.Add(name);
                }

            }

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{match.Count} emojis found in the text. The cool ones are:");

            for (int j = 0; j < dataList.Count; j++)
            {
                Console.WriteLine(dataList[j]);
            }

        }
    }
}
