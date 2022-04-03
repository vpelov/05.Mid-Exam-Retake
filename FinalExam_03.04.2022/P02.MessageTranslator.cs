using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"\![A-Z]{1}[a-z]{2,}\![\:]\[[A-Za-z]{8,}\]";

            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();

                Match match = Regex.Match(text, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("The message is invalid");
                }
                else
                {
                    string textReg = match.ToString();
                    string[] command = textReg.Split(':', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string printCommand = command[0];
                    printCommand = printCommand.Remove(0, 1);
                    printCommand = printCommand.Remove(printCommand.Length - 1, 1);

                    char[] number = command[1].ToCharArray();

                    Console.Write($"{printCommand}: ");

                    for (int j = 1; j < number.Length - 1; j++)
                    {
                        Console.Write($"{(int)number[j]} ");
                    }
                    Console.WriteLine();


                }

            }



        }
    }
}
