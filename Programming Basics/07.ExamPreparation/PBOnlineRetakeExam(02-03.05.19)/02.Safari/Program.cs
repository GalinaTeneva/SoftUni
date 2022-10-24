using System;

namespace _02.Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPricePerLitter = 2.10;
            double gidPrice = 100;
            double saturdayDiscount = 0.1;
            double sundayDiscount = 0.2;

            double budget = double.Parse(Console.ReadLine());
            double neededFuel = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            double safariCost = (neededFuel * fuelPricePerLitter) + gidPrice;

            if (day == "Saturday")
            {
                safariCost -= safariCost * saturdayDiscount;
            }
            else if (day == "Sunday")
            {
                safariCost -= safariCost * sundayDiscount;
            }

            if (budget >= safariCost)
            {
                double diff = budget - safariCost;
                Console.WriteLine($"Safari time! Money left: {diff:F2} lv. ");
            }
            else
            {
                double diff = safariCost - budget;
                Console.WriteLine($"Not enough money! Money needed: {diff:F2} lv.");
            }
        }
    }
}
