using System;

namespace _01.Birthday_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine());

            double cakePrice = hallRent * 0.2;
            double drinksPrice = cakePrice - (cakePrice * 0.45);
            double animatorPrice = hallRent / 3;

            double totalCost = hallRent + cakePrice + drinksPrice + animatorPrice;
            Console.WriteLine(totalCost);
        }
    }
}
