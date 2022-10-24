using System;

namespace _04.Club
{
    class Program
    {
        static void Main(string[] args)
        {
            double requiredProfit = double.Parse(Console.ReadLine());

            double earnedMoney = 0;
            while (earnedMoney < requiredProfit)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                int cocktailsNum = int.Parse(Console.ReadLine());
                double currentOrderPrice = cocktailsNum * input.Length;

                if (currentOrderPrice % 2 != 0)
                {
                    currentOrderPrice -= currentOrderPrice * 0.25;
                }

                earnedMoney += currentOrderPrice;
            }

            if (earnedMoney < requiredProfit)
            {
                double moneySortage = requiredProfit - earnedMoney;
                Console.WriteLine($"We need {moneySortage:F2} leva more.");
            }
            else
            {
                Console.WriteLine("Target acquired.");
            }

            Console.WriteLine($"Club income - {earnedMoney:F2} leva.");
        }
    }
}
