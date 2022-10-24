using System;

namespace _02.Cat_Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesPerWalk = int.Parse(Console.ReadLine());
            int walksPerDay = int.Parse(Console.ReadLine());
            int calories = int.Parse(Console.ReadLine());

            int burnedCaloriesPerMin = 5;

            int totalBurnedCalories = minutesPerWalk * walksPerDay * burnedCaloriesPerMin;

            if (totalBurnedCalories >= (calories / 2))
            {
                Console.WriteLine($"Yes, the walk for your cat is enough. Burned calories per day: {totalBurnedCalories}.");
            }
            else
            {
                Console.WriteLine($"No, the walk for your cat is not enough. Burned calories per day: {totalBurnedCalories}.");
            }
        }
    }
}
