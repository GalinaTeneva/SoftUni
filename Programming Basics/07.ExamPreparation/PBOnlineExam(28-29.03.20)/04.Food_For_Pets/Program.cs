using System;

namespace _04.Food_For_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double foodQuantity = double.Parse(Console.ReadLine());

            double biscuitsQuantity = 0;
            double totalFoodForDog = 0;
            double totalFoodForCat = 0;
            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                int foodForDog = int.Parse(Console.ReadLine());
                int foodForCat = int.Parse(Console.ReadLine());

                totalFoodForDog += foodForDog;
                totalFoodForCat += foodForCat;

                if (currentDay % 3 == 0)
                {
                    biscuitsQuantity += (foodForDog + foodForCat) * 0.1;
                }
            }

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuitsQuantity)}gr.");

            double totalEatenFoodPercent = (totalFoodForDog + totalFoodForCat) / foodQuantity * 100;
            Console.WriteLine($"{totalEatenFoodPercent:f2}% of the food has been eaten.");

            double foodForDogPercent = totalFoodForDog / (totalFoodForDog + totalFoodForCat) * 100;
            double foodForCatPercent = totalFoodForCat / (totalFoodForDog + totalFoodForCat) * 100;

            Console.WriteLine($"{foodForDogPercent:f2}% eaten from the dog.");
            Console.WriteLine($"{foodForCatPercent:f2}% eaten from the cat.");
        }
    }
}
