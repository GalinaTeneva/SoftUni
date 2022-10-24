using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            const int KcalPerDay = 2000;
            string pattern = @"([#|\|])(?<itemType>[A-Za-z ]+)\1(?<expiration>[\d]{2}/[\d]{2}/[\d]{2})\1(?<calories>\d+)\1";

            string input = Console.ReadLine();

            MatchCollection foodItems = Regex.Matches(input, pattern);

            int totalCalories = 0;
            foreach (Match item in foodItems)
            {
                totalCalories += int.Parse(item.Groups["calories"].Value);
            }

            int days = totalCalories / KcalPerDay;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (Match item in foodItems)
            {
                Console.WriteLine($"Item: {item.Groups["itemType"].Value}, Best before: {item.Groups["expiration"].Value}, Nutrition: {item.Groups["calories"].Value}");
            }
        }
    }
}
