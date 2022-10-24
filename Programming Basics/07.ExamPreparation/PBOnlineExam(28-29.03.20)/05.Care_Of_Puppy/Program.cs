using System;

namespace _05.Care_Of_Puppy
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodInStockInKilos = int.Parse(Console.ReadLine());

            int foodInStockInGrams = foodInStockInKilos * 1000;

            string command;
            while ((command = Console.ReadLine()) != "Adopted")
            {
                int currentMealFoodInGrams = int.Parse(command);
                foodInStockInGrams -= currentMealFoodInGrams;
            }

            if (foodInStockInGrams < 0)
            {
                Console.WriteLine($"Food is not enough. You need {Math.Abs(foodInStockInGrams)} grams more.");
            }
            else
            {
                Console.WriteLine($"Food is enough! Leftovers: {Math.Abs(foodInStockInGrams)} grams.");
            }
        }
    }
}
