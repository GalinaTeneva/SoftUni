using System;

namespace _07.Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuCount = int.Parse(Console.ReadLine());
            int processorCount = int.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());

            double gpuPrice = 250;
            double processorPrice = 0.35 * gpuPrice * gpuCount;
            double ramPrice = 0.1 * gpuPrice * gpuCount;
            double discount = 0.15;

            double totalCost = gpuPrice * gpuCount + processorPrice * processorCount + ramCount * ramPrice;

            if (gpuCount > processorCount)
            {
                double discountAmount = totalCost * discount;
                totalCost -= discountAmount;
            }

            if (budget >= totalCost)
            {
                double moneyLeft = budget - totalCost;
                Console.WriteLine($"You have {moneyLeft:f2} leva left!");
            }
            else
            {
                double moneyShortage = totalCost - budget;
                Console.WriteLine($"Not enough money! You need {moneyShortage:f2} leva more!");
            }
        }
    }
}
