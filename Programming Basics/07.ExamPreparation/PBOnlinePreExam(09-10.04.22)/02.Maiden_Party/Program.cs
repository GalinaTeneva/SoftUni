using System;

namespace _02.Maiden_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double loveLetterPrice = 0.60;
            double waxRosePrice = 7.20;
            double keyChainPrice = 3.60;
            double cartoonPrice = 18.20;
            double surpriseLuckPrice = 22;
            double hostingCostPercent = 0.1;

            double maidenPartyCost = double.Parse(Console.ReadLine());
            int loveLettersNum = int.Parse(Console.ReadLine());
            int waxRosesNum = int.Parse(Console.ReadLine());
            int keyChainsNum = int.Parse(Console.ReadLine());
            int cartoonsNum = int.Parse(Console.ReadLine());
            int surpriseLuckNum = int.Parse(Console.ReadLine());

            double loveLettersProfit = loveLetterPrice * loveLettersNum;
            double waxRosesProfit = waxRosePrice * waxRosesNum;
            double keyChainsProfit = keyChainPrice * keyChainsNum;
            double cartoonsProfit = cartoonPrice * cartoonsNum;
            double surpriseLuckProfit = surpriseLuckPrice * surpriseLuckNum;
            double totalProfit = loveLettersProfit + waxRosesProfit + keyChainsProfit + cartoonsProfit + surpriseLuckProfit;

            int soldItems = loveLettersNum + waxRosesNum + keyChainsNum + cartoonsNum + surpriseLuckNum;
            if (soldItems >= 25)
            {
                totalProfit -= totalProfit * 0.35;
            }

            totalProfit -= totalProfit * hostingCostPercent;

            if (totalProfit >= maidenPartyCost)
            {
                double diff = totalProfit - maidenPartyCost;
                Console.WriteLine($"Yes! {diff:F2} lv left.");
            }
            else
            {
                double diff = maidenPartyCost - totalProfit;
                Console.WriteLine($"Not enough money! {diff:F2} lv needed.");
            }
        }
    }
}
