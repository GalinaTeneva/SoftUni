using System;

namespace _05.Excursion_Sale
{
    class Program
    {
        static void Main(string[] args)
        {
            int seaЕxcursionPrice = 680;
            int mountainЕxcursionPrice = 499;

            int seaЕxcursionsNum = int.Parse(Console.ReadLine());
            int mountainЕxcursionsNum = int.Parse(Console.ReadLine());

            int totalProfit = 0;
            while (seaЕxcursionsNum != 0 || mountainЕxcursionsNum != 0)
            {
                string currentExcursion = Console.ReadLine();

                if (currentExcursion == "Stop")
                {
                    break;
                }
                else if (currentExcursion == "sea")
                {
                    if (seaЕxcursionsNum > 0)
                    {
                        totalProfit += seaЕxcursionPrice;
                        seaЕxcursionsNum--;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (currentExcursion == "mountain")
                {
                    if (mountainЕxcursionsNum > 0)
                    {
                        totalProfit += mountainЕxcursionPrice;
                        mountainЕxcursionsNum--;
                    }
                    else
                    {
                        continue;
                    }
                }

            }

            if (seaЕxcursionsNum <= 0 && mountainЕxcursionsNum <= 0)
            {
                Console.WriteLine("Good job! Everything is sold.");
            }
            Console.WriteLine("Profit: {0} leva.", totalProfit);
        }
    }
}
