using System;

namespace _12.Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());

            double commisionPercent = 0;

            switch (town)
            {
                case "Sofia":
                    if (sells >= 0 && sells <= 500)
                    {
                        commisionPercent = 0.05;
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        commisionPercent = 0.07;
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        commisionPercent = 0.08;
                    }
                    else if (sells > 10000)
                    {
                        commisionPercent = 0.12;
                    }
                    break;
                case "Varna":
                    if (sells >= 0 && sells <= 500)
                    {
                        commisionPercent = 4.5 / 100;
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        commisionPercent = 7.5 / 100;
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        commisionPercent = 10.0 / 100;
                    }
                    else if (sells > 10000)
                    {
                        commisionPercent = 13.0 / 100;
                    }
                    break;
                case "Plovdiv":
                    if (sells >= 0 && sells <= 500)
                    {
                        commisionPercent = 5.5 / 100;
                    }
                    else if (sells > 500 && sells <= 1000)
                    {
                        commisionPercent = 8.0 / 100;
                    }
                    else if (sells > 1000 && sells <= 10000)
                    {
                        commisionPercent = 12.0 / 100;
                    }
                    else if (sells > 10000)
                    {
                        commisionPercent = 14.5 / 100;
                    }
                    break;
            }

            double commision = sells * commisionPercent;
            if (commisionPercent != 0)
            {
                Console.WriteLine($"{commision:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
