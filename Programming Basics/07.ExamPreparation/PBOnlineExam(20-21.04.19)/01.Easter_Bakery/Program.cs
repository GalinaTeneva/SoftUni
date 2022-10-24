using System;

namespace _01.Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPrice = double.Parse(Console.ReadLine());
            double flourKilos = double.Parse(Console.ReadLine());
            double sugarKilos = double.Parse(Console.ReadLine());
            int eggsPackagesNum = int.Parse(Console.ReadLine());
            int yeastPackagesNum = int.Parse(Console.ReadLine());

            double sugarPrice = flourPrice - (flourPrice * 0.25);
            double eggsPackagePrice = flourPrice + (flourPrice * 0.1);
            double yeastPackagePrice = sugarPrice - (sugarPrice * 0.8);

            double totalCost = (flourPrice * flourKilos) + (sugarPrice * sugarKilos) + (eggsPackagePrice * eggsPackagesNum) + (yeastPackagePrice * yeastPackagesNum);

            Console.WriteLine("{0:F2}", totalCost);

        }
    }
}
