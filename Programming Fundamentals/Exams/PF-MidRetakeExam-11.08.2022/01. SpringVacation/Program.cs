using System;

namespace _01._SpringVacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            double fuelPricePerKilometer = double.Parse(Console.ReadLine());
            double foodExpensesPerPersonPerDay = double.Parse(Console.ReadLine());
            double roomPricePerPersonPerNight = double.Parse(Console.ReadLine());

            if (people > 10)
            {
                double discountPercent = 0.25;
                roomPricePerPersonPerNight -= roomPricePerPersonPerNight * discountPercent;
            }

            double initialExpenses = days * people * (foodExpensesPerPersonPerDay + roomPricePerPersonPerNight);

            double totalCost = initialExpenses;

            for (int currDay = 1; currDay <= days; currDay++)
            {
                double currDayTraveledDistance = double.Parse(Console.ReadLine());
                totalCost += fuelPricePerKilometer * currDayTraveledDistance;
                
                if (currDay % 3 == 0 || currDay % 5 == 0)
                {
                    double additionalCostPercent = 0.4;
                    totalCost += totalCost * additionalCostPercent;
                }
                if (currDay % 7 == 0)
                {
                    totalCost -= totalCost / people;
                }

                if (totalCost > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {totalCost - budget:F2}$ more.");
                    break;
                }
            }

            if (budget >= totalCost)
            {
                Console.WriteLine($"You have reached the destination. You have {budget - totalCost:F2}$ budget left.");

            }

        }
    }
}
