using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.FancyBarcodes_new
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[\@]{1}[\#]+(?<name>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1})[\@]{1}[\#]{1,}";

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcodes = Console.ReadLine();
                Match match = Regex.Match(barcodes, pattern);

                if (match.Success)
                {
                    char[] charArr = match.ToString().ToCharArray();
                    string productGroup = string.Empty;

                    for (int j = 0; j < charArr.Length; j++)
                    {
                        if (char.IsDigit(charArr[j]))
                        {
                            productGroup += charArr[j];
                        }
                    }

                    if (productGroup == string.Empty)
                    {
                        productGroup = "00";
                    }
                    Console.WriteLine($"Product group: {productGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }         

        }
    }
}
