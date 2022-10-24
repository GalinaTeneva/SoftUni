using System;

namespace _4.Vegetable_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerKiloVeggieLv = double.Parse(Console.ReadLine());
            double pricePerKiloFruitsLv = double.Parse(Console.ReadLine());
            int kilosVeggies = int.Parse(Console.ReadLine());
            int kilosFruits = int.Parse(Console.ReadLine());
            double rateEuroLv = 1.94;

            double priceForVegies = pricePerKiloVeggieLv * kilosVeggies;
            double priceForFruits = pricePerKiloFruitsLv * kilosFruits;
            double totalPriceLv = priceForVegies + priceForFruits;
            double totalPriceEuro = totalPriceLv / rateEuroLv;

            Console.WriteLine($"{totalPriceEuro:F2}");
        }
    }
}
