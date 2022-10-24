using System;

namespace _01.Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double racketPrice = double.Parse(Console.ReadLine());
            int racketsNum = int.Parse(Console.ReadLine());
            int sneakersNum = int.Parse(Console.ReadLine());

            double sneakersPrice = racketPrice / 6;
            double accessoriesPrice = (racketPrice * racketsNum + sneakersPrice * sneakersNum) * 0.2;
            double totalCost = (racketPrice * racketsNum + sneakersPrice * sneakersNum) + accessoriesPrice;

            double costForThePlayer = totalCost / 8;
            double costForTheSponsor = totalCost - costForThePlayer;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(costForThePlayer)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(costForTheSponsor)}");

        }
    }
}
