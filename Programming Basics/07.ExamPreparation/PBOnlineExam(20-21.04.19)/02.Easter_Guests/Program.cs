using System;

namespace _02.Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            double easterCakePrice = 4.00;
            double eggPrice = 0.45;

            int guestsNum = int.Parse(Console.ReadLine ());
            int budget = int.Parse(Console.ReadLine ());

            double easterCakesNum = Math.Ceiling((double)guestsNum / 3);
            double eggsNum = guestsNum * 2;

            double totalCost = easterCakePrice * easterCakesNum + eggPrice * eggsNum;

            if (totalCost <= budget)
            {
                double diff = budget - totalCost;
                Console.WriteLine($"Lyubo bought {easterCakesNum} Easter bread and {eggsNum} eggs.");
                Console.WriteLine($"He has {diff:F2} lv. left.");
            }
            else
            {
                double diff = totalCost - budget;
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {diff:F2} lv. more.");
            }
        }
    }
}
