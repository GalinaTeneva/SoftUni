using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            byte beerKegsNum = byte.Parse(Console.ReadLine());

            double maxVolOfABeerKeg = 0;
            string modelOfBeerKegWithMaxVol = " ";
            for (int currentBeerKeg = 1; currentBeerKeg <= beerKegsNum; currentBeerKeg++)
            {
                string currentBeerKegModel = Console.ReadLine();
                double currentBeerKegRadius = double.Parse(Console.ReadLine());
                int currentBeerKegHeight = int.Parse(Console.ReadLine());

                double currentBeerKegVol = Math.PI * Math.Pow(currentBeerKegRadius, 2) * currentBeerKegHeight;

                if (currentBeerKegVol > maxVolOfABeerKeg)
                {
                    maxVolOfABeerKeg = currentBeerKegVol;
                    modelOfBeerKegWithMaxVol = currentBeerKegModel;
                }
            }

            Console.WriteLine(modelOfBeerKegWithMaxVol);
        }
    }
}
