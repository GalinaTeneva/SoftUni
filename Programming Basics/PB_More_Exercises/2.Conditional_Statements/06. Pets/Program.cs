using System;

namespace _06._Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int availableFoodInKilos = int.Parse(Console.ReadLine());
            double dogFoodPerDayInKilos = double.Parse(Console.ReadLine());
            double catFoodPerDayInKilos = double.Parse(Console.ReadLine());
            double tortoiseFoodPerDayInGrams = double.Parse(Console.ReadLine());

            double tortoiseFoodPerDayInKilos = tortoiseFoodPerDayInGrams / 1000;

            double totalDogFood = dogFoodPerDayInKilos * days;
            double totalCatFood = catFoodPerDayInKilos * days;
            double totalTortoiseFood = tortoiseFoodPerDayInKilos * days;
            double neededAnimalFood = totalDogFood + totalCatFood + totalTortoiseFood;

            if (availableFoodInKilos >= neededAnimalFood)
            {
                double foodLeft = availableFoodInKilos - neededAnimalFood;
                Console.WriteLine($"{Math.Floor(foodLeft)} kilos of food left.");
            }
            else
            {
                double foodShortage = neededAnimalFood - availableFoodInKilos;
                Console.WriteLine($"{Math.Ceiling(foodShortage)} more kilos of food are needed.");
            }
        }
    }
}
