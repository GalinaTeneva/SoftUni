using System;

namespace _02.Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNum = int.Parse(Console.ReadLine());
            double reservationPricePerPerson = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double cakePrice = budget * 0.1;

            double discount = 0;
            if (guestsNum >= 10 && guestsNum <= 15)
            {
                discount = 0.15;
            }
            else if (guestsNum > 15 && guestsNum <= 20)
            {
                discount = 0.2;
            }
            else if (guestsNum > 20)
            {
                discount = 0.25;
            }

            double discountAmount = reservationPricePerPerson * discount;
            double totalCost = (reservationPricePerPerson - discountAmount) * guestsNum + cakePrice;

            if (budget >= totalCost)
            {
                double diff = budget - totalCost;
                Console.WriteLine($"It is party time! {diff:F2} leva left.");
            }
            else
            {
                double diff = totalCost - budget;
                Console.WriteLine($"No party! {diff:F2} leva needed.");
            }

        }
    }
}
