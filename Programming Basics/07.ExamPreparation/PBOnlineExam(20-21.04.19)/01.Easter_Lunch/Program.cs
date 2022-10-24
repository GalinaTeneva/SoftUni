using System;

namespace _01.Easter_Lunch
{
    class Program
    {
        static void Main(string[] args)
        {
            double easterCakePrice = 3.20;
            double eggPackagePrice = 4.35;
            int eggsPerOnePackage = 12;
            double cookiePeicePerKilo = 5.40;
            double eggPaintPricePerEgg = 0.15;

            int easterCakeNum = int.Parse(Console.ReadLine());
            int eggsPackageNum = int.Parse(Console.ReadLine());
            int cookiesKilos = int.Parse(Console.ReadLine());

            double totalForEasterCake = easterCakePrice * easterCakeNum;
            double totalForeEggs = eggPackagePrice * eggsPackageNum;
            double totalForCookies = cookiePeicePerKilo * cookiesKilos;
            double totalForEggPaint = eggsPackageNum * eggsPerOnePackage * eggPaintPricePerEgg;
            double totalCost = totalForEasterCake + totalForeEggs + totalForCookies + totalForEggPaint;

            Console.WriteLine($"{totalCost:F2}");
        }
    }
}
