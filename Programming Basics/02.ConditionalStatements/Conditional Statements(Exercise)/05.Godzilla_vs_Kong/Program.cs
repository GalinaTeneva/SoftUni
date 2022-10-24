using System;

namespace _05.Godzilla_vs_Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double filmBudget = double.Parse(Console.ReadLine());
            int stuntmen = int.Parse(Console.ReadLine());
            double outfitFor1stuntmen = double.Parse(Console.ReadLine());

            double setCost = filmBudget * 0.1;
            double discount = 0.1;

            double moneyForOutfit = stuntmen * outfitFor1stuntmen;
            double finalCost = moneyForOutfit  + setCost;

            if (stuntmen > 150)
            {
                double discountAmount = moneyForOutfit * discount;
                finalCost = moneyForOutfit + setCost - discountAmount;
            }

            if (finalCost > filmBudget)
            {
                double moneyShortage = finalCost - filmBudget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {moneyShortage:f2} leva more.");
            }
            else if (finalCost <= filmBudget)
            {
                double moneyLeft = filmBudget - finalCost;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {moneyLeft:f2} leva left.");
            }
        }
    }
}
