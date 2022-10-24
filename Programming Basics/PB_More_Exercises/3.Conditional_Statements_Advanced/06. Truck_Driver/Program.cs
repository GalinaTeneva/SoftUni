using System;

namespace _06._Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kilometersPerMonth = double.Parse(Console.ReadLine());

            double taxsPercent = 0.10;
            int montsInOneSeason = 4;
            double pricePerKilometer = 0;

            if (kilometersPerMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKilometer = 0.75;
                }
                else if (season == "Summer")
                {
                    pricePerKilometer = 0.90;
                }
                else if (season == "Winter")
                {
                    pricePerKilometer = 1.05;
                }
            }
            else if (kilometersPerMonth > 5000 && kilometersPerMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    pricePerKilometer = 0.95;
                }
                else if (season == "Summer")
                {
                    pricePerKilometer = 1.10;
                }
                else if (season == "Winter")
                {
                    pricePerKilometer = 1.25;
                }
            }
            else if (kilometersPerMonth > 10000 && kilometersPerMonth <= 20000)
            {
                    pricePerKilometer = 1.45;
            }

            double totalIncome = kilometersPerMonth * pricePerKilometer * montsInOneSeason;
            double profit = totalIncome - (totalIncome * taxsPercent);

            Console.WriteLine($"{profit:F2}");
        }
    }
}
