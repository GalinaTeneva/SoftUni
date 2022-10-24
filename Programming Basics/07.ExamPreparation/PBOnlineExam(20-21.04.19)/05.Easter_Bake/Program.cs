using System;

namespace _05.Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int easterCakesNum = int.Parse(Console.ReadLine());

            double totalSugarNeeded = 0;
            double totalFlourNeeded = 0;
            int maxSugarUsed = 0;
            int maxFlourUsed = 0;
            for (int currentEasterCake = 1; currentEasterCake <= easterCakesNum; currentEasterCake++)
            {
                int currentCakeSugar = int.Parse(Console.ReadLine());
                int currentCakeFlour = int.Parse(Console.ReadLine());

                totalSugarNeeded += currentCakeSugar;
                totalFlourNeeded += currentCakeFlour;

                if (currentCakeSugar > maxSugarUsed)
                {
                    maxSugarUsed = currentCakeSugar;
                }
                if (currentCakeFlour > maxFlourUsed)
                {
                    maxFlourUsed = currentCakeFlour;
                }
            }

            double packagesSugarNeeded = Math.Ceiling(totalSugarNeeded / 950);
            double packagesFlourNeeded = Math.Ceiling(totalFlourNeeded / 750);

            Console.WriteLine($"Sugar: {packagesSugarNeeded}");
            Console.WriteLine($"Flour: {packagesFlourNeeded}");
            Console.WriteLine($"Max used flour is {maxFlourUsed} grams, max used sugar is {maxSugarUsed} grams.");
        }
    }
}
