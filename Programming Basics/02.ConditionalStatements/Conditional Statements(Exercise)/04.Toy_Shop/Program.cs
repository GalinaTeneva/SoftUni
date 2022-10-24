using System;

namespace _04.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = 0.1;

            double puzzlePrice = 2.60;
            double dollPrize = 3;
            double teddyBearPrize = 4.10;
            double minuonPrize = 8.20;
            double truckPrize = 2;

            double excursionCost = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int teddyBearCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());

            double discount = 0.25;
            int totalToys = puzzleCount + dollCount + teddyBearCount + minionCount + truckCount;

            double totalPrice = puzzleCount * puzzlePrice + dollCount * dollPrize + teddyBearCount * teddyBearPrize 
                                 + minionCount * minuonPrize + truckCount * truckPrize; 
            if (totalToys >= 50)
            {
                totalPrice -= totalPrice * discount; 
            }

            double rentCost = totalPrice * rent;
            double profit = totalPrice - rentCost;

            if (excursionCost <= profit)
            {
                double moneyLeft = profit - excursionCost;
                Console.WriteLine($"Yes! {moneyLeft:f2} lv left.");
            }
            else if (excursionCost > profit)
            {
                double moneyShortage = excursionCost - profit;
                Console.WriteLine($"Not enough money! {moneyShortage:f2} lv needed.");

                
            }
        }
    }
}
