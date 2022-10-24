using System;

namespace _01.Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int yearlyFee = int.Parse(Console.ReadLine());

            double sneakersPrice = yearlyFee - (yearlyFee * 0.4);
            double outfitPrice = sneakersPrice - (sneakersPrice * 0.2);
            double ballPrice = outfitPrice / 4;
            double accessoriesPrice = ballPrice / 5;

            double totalCost = yearlyFee + sneakersPrice + outfitPrice + ballPrice + accessoriesPrice;

            Console.WriteLine($"{totalCost:F2}");
        }
    }
}
