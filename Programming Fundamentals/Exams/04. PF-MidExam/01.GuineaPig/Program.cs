using System;

namespace _01.GuineaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            const int EatenFoodPerDay = 300;
            const double HayPercenPerDay = 0.05;

            double quantityFoodInGram = double.Parse(Console.ReadLine()) * 1000;
            double quantityHayInGram = double.Parse(Console.ReadLine()) * 1000;
            double quantityCoverInGram = double.Parse(Console.ReadLine()) * 1000;
            double guineaWeightInGram = double.Parse(Console.ReadLine()) * 1000;

            int daysCounter = 0;
            while (quantityFoodInGram > 0 && quantityHayInGram > 0 && quantityCoverInGram > 0)
            {
                daysCounter++;
                quantityFoodInGram -= EatenFoodPerDay;

                if (daysCounter % 2 == 0)
                {
                    quantityHayInGram -= quantityFoodInGram * HayPercenPerDay;
                }
                if (daysCounter % 3 == 0)
                {
                    quantityCoverInGram -= guineaWeightInGram / 3;
                }
                if (daysCounter == 30)
                {
                    break;
                }
            }

            if (quantityFoodInGram > 0 && quantityHayInGram > 0 && quantityCoverInGram > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {(quantityFoodInGram / 1000):F2}, Hay: {(quantityHayInGram / 1000):F2}, Cover: {(quantityCoverInGram / 1000):F2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}
