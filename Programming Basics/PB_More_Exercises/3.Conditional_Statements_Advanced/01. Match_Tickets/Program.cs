using System;

namespace _01._Match_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double tiketPriceVIP = 499.99;
            double tiketPriceNormal = 249.99;

            double budget = double.Parse(Console.ReadLine());
            string categoryName = Console.ReadLine();
            int peopleInTheGroup = int.Parse(Console.ReadLine());

            double transportCost = 0;
            double neededMoneyForTikets = 0;

            if (categoryName == "VIP")
            {
                neededMoneyForTikets = peopleInTheGroup * tiketPriceVIP;

                if (peopleInTheGroup >= 1 && peopleInTheGroup <= 4)
                {
                    transportCost = budget * 0.75;
                }
                else if (peopleInTheGroup >= 5 && peopleInTheGroup <= 9)
                {
                    transportCost = budget * 0.60;
                }
                else if (peopleInTheGroup >= 10 && peopleInTheGroup <= 24)
                {
                    transportCost = budget * 0.50;
                }
                else if (peopleInTheGroup >= 25 && peopleInTheGroup <= 49)
                {
                    transportCost = budget * 0.40;
                }
                else if (peopleInTheGroup >= 50)
                {
                    transportCost = budget * 0.25;
                }
            }
            else if (categoryName == "Normal")
            {
                neededMoneyForTikets = peopleInTheGroup * tiketPriceNormal;

                if (peopleInTheGroup >= 1 && peopleInTheGroup <= 4)
                {
                    transportCost = budget * 0.75;
                }
                else if (peopleInTheGroup >= 5 && peopleInTheGroup <= 9)
                {
                    transportCost = budget * 0.60;
                }
                else if (peopleInTheGroup >= 10 && peopleInTheGroup <= 24)
                {
                    transportCost = budget * 0.50;
                }
                else if (peopleInTheGroup >= 25 && peopleInTheGroup <= 49)
                {
                    transportCost = budget * 0.40;
                }
                else if (peopleInTheGroup >= 50)
                {
                    transportCost = budget * 0.25;
                }
            }

            double avaiableMoneyForTikets = budget - transportCost;
            if (avaiableMoneyForTikets >= neededMoneyForTikets)
            {
                Console.WriteLine($"Yes! You have {(avaiableMoneyForTikets - neededMoneyForTikets):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {(neededMoneyForTikets - avaiableMoneyForTikets):F2} leva.");
            }
        }
    }
}