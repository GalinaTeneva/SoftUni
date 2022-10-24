using System;

namespace _02._Report_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededMoney = int.Parse(Console.ReadLine());

            string input = " ";
            int counter = 0;
            int moneyRaised = 0;
            double moneRaisedWithCard = 0;
            double moneyRaisedInCash = 0;
            int paidWithCardCounter = 0;
            int paidInCashCounter = 0;
            while ((input = Console.ReadLine()) != "End")
            {
                int currentItemPrice = int.Parse(input);
                counter++;
                if (counter % 2 == 0 )  // with card
                {
                    if (currentItemPrice < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        moneRaisedWithCard += currentItemPrice;
                        paidWithCardCounter++;
                    }
                }
                else    // cash
                {
                    if (currentItemPrice > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        moneyRaisedInCash += currentItemPrice;
                        paidInCashCounter++;
                    }
                }

                moneyRaised += currentItemPrice;
                if (moneyRaised >= neededMoney)
                {
                    double averageInCash = moneyRaisedInCash / paidInCashCounter;
                    double averageWithCard = moneRaisedWithCard / paidWithCardCounter;

                    Console.WriteLine($"Average CS: {averageInCash:F2}");
                    Console.WriteLine($"Average CC: {averageWithCard:F2}");
                    break;
                }
            }

            if (input == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
