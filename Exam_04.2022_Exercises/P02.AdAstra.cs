using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P02.AdAstra
{
    class Food
    {
        public Food(string name, string date, int nutrition)
        {
            this.Name = name;
            this.Date = date;
            this.Nutrition = nutrition;
        }

        public string Name { get; set; }

        public string Date { get; set; }

        public int Nutrition { get; set; }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Food> foodList = new List<Food>();
            string text = Console.ReadLine();
            string pattern = @"(\||\#)(?<name>[A-Za-z ]+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>[0-9]{1,4})\1";

            MatchCollection match = Regex.Matches(text, pattern);

            foreach (Match item in match)
            {
                string name = item.Groups["name"].Value;
                string date = item.Groups["date"].Value;
                int calories = int.Parse(item.Groups["calories"].Value);
                Food newFood = new Food(name, date, calories);
                foodList.Add(newFood);
            }

            int allCalories = 0;
            foreach (Food item in foodList)
            {
                allCalories += item.Nutrition;
            }

            Console.WriteLine($"You have food to last you for: {allCalories / 2000} days!");
            foreach (Food item in foodList)
            {
                Console.WriteLine($"Item: {item.Name}, Best before: {item.Date}, Nutrition: {item.Nutrition}");
            }
        }
    }
}
