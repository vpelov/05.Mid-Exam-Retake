using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([\@]{1}|[\#]{1})[A-Za-z]{3,}\1\1[A-Za-z]{3,}\1";

            MatchCollection match = Regex.Matches(text, pattern);

            List<string> pairList = new List<string>();
            if (match.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                int countValidPairs = 0;
                foreach (Match item in match)
                {
                    countValidPairs++;
                    string currentString = item.ToString();
                    currentString = currentString.Replace('@', ' ').Replace('#', ' ');
                    string[] pair = currentString
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    string pairOne = pair[0];
                    string pairTwo = pair[1];

                    char[] currentCh = pairTwo.ToCharArray();
                    Array.Reverse(currentCh);
                    string currStr = String.Join("", currentCh);
                    if (pairOne == currStr)
                    {
                        string print = pairOne + " <=> " + pairTwo;
                        pairList.Add(print);
                    }
                                        
                }

                Console.WriteLine($"{countValidPairs} word pairs found!");
            }

            if (pairList.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");

                Console.WriteLine(string.Join(", ", pairList));
            }
        }
    }
}
