using System;

namespace _04.Tourist_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());

            int productsCounter = 0;
            double totalCost = 0;
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                double currentProductPrice = double.Parse(Console.ReadLine());

                productsCounter++;
                if (productsCounter % 3 == 0)
                {
                    currentProductPrice /= 2;
                }

                if (currentProductPrice > budget)
                {
                    double diff = currentProductPrice - budget;
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {diff:F2} leva!");
                    break;
                }

                budget -= currentProductPrice;
                totalCost += currentProductPrice;
            }

            if (input == "Stop")
            {
                Console.WriteLine($"You bought {productsCounter} products for {totalCost:F2} leva.");
            }
        }
    }
}
