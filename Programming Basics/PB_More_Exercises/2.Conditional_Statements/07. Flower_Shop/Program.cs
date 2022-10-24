using System;

namespace _07._Flower_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double magnoliaPrice = 3.25;
            double hyacinthPrice = 4;
            double rosePrice = 3.50;
            double cactusPrice = 8;
            double taxPercent = 0.05;

            int magnoliaNum = int.Parse(Console.ReadLine());
            int hyacinthNum = int.Parse(Console.ReadLine());
            int roseNum = int.Parse(Console.ReadLine());
            int cactusNum = int.Parse(Console.ReadLine());
            double presentPrice = double.Parse(Console.ReadLine());

            double magnoliaTurnover = magnoliaPrice * magnoliaNum;
            double hyacinthTurnover = hyacinthPrice * hyacinthNum;
            double roseTurnover = rosePrice * roseNum;
            double cactusTurnover = cactusPrice * cactusNum;
            double totalTurnover = magnoliaTurnover + hyacinthTurnover + roseTurnover + cactusTurnover;
            double income = totalTurnover - totalTurnover * taxPercent;

            if (income >= presentPrice)
            {
                double moneyLeft = income - presentPrice;
                Console.WriteLine($"She is left with {Math.Floor(moneyLeft)} leva.");
            }
            else
            {
                double moneyShortage = presentPrice - income;
                Console.WriteLine($"She will have to borrow {Math.Ceiling(moneyShortage)} leva.");
            }
        }
    }
}
