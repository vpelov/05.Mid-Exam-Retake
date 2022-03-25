using System;
using System.Text.RegularExpressions;

namespace P02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberBarcodes; i++)
            {
                string inputData = Console.ReadLine();
                string pattern = @"(\@{1}\#+)[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1}\1";

                Match match = Regex.Match(inputData, pattern);
                if (match.Success)
                {
                    string number = string.Empty;
                    char[] input = inputData.ToCharArray();
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            number += input[j];
                        }
                    }

                    if (number.Length == 0)
                    {
                        number += "00";
                    }

                    if (number == "00")
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        int num = int.Parse(number);
                        Console.WriteLine($"Product group: {num}");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }                
            }

        }
    }
}
