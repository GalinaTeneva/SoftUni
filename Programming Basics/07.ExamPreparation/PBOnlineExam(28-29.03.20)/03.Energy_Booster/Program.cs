using System;

namespace _03.Energy_Booster
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string setType = Console.ReadLine();
            int setsNum = int.Parse(Console.ReadLine());

            int smallSetItemsNum = 2;
            int bigSetItemsNum = 5;

            double price = 0;
            if (fruit == "Watermelon")
            {
                if (setType == "small")
                {
                    price = 56.00 * smallSetItemsNum;
                }
                else if (setType == "big")
                {
                    price = 28.70 * bigSetItemsNum;
                }
            }
            else if (fruit == "Mango")
            {
                if (setType == "small")
                {
                    price = 36.66 * smallSetItemsNum;
                }
                else if (setType == "big")
                {
                    price = 19.60 * bigSetItemsNum;
                }
            }
            else if (fruit == "Pineapple")
            {
                if (setType == "small")
                {
                    price = 42.10 * smallSetItemsNum;
                }
                else if (setType == "big")
                {
                    price = 24.80 * bigSetItemsNum;
                }
            }
            else if (fruit == "Raspberry")
            {
                if (setType == "small")
                {
                    price = 20.00 * smallSetItemsNum;
                }
                else if (setType == "big")
                {
                    price = 15.20 * bigSetItemsNum;
                }
            }

            double orderCost = price * setsNum;

            double discount = 0;
            if (orderCost >= 400 && orderCost <= 1000)
            {
                discount = 0.15;
                orderCost -= orderCost * discount;
            }
            else if (orderCost > 1000)
            {
                discount = 0.5;
                orderCost -= orderCost * discount;
            }

            Console.WriteLine($"{orderCost:F2} lv.");

        }
    }
}
