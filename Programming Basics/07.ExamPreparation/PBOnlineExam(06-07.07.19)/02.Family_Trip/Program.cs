using System;

namespace _02.Family_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int totalNights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int additionalCostsPercent = int.Parse(Console.ReadLine());

            if (totalNights > 7)
            {
                pricePerNight -= pricePerNight * 0.05;
            }

            double additionalCosts = budget * additionalCostsPercent / 100;

            double finalPrice = (totalNights * pricePerNight) + additionalCosts;

            double diff = budget - finalPrice;

            if (finalPrice <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {Math.Abs(diff):F2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{Math.Abs(diff):F2} leva needed.");
            }
        }
    }
}
