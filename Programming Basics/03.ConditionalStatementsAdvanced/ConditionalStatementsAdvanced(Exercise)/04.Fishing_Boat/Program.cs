using System;

namespace _04.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            int rent = 0;
            double discount = 0;
            double totalCost = 0;

            if (season == "Spring")
            {
                rent = 3000;
                if (fishermen <= 6)
                {
                    discount = 0.1;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    discount = 0.15;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 12)
                {
                    discount = 0.25;
                    totalCost = rent - rent * discount;
                }
            }
            else if (season == "Summer")
            {
                rent = 4200;
                if (fishermen <= 6)
                {
                    discount = 0.1;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    discount = 0.15;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 12)
                {
                    discount = 0.25;
                    totalCost = rent - rent * discount;
                }
            }
            else if (season == "Autumn")
            {
                rent = 4200;
                if (fishermen <= 6)
                {
                    discount = 0.1;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    discount = 0.15;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 12)
                {
                    discount = 0.25;
                    totalCost = rent - rent * discount;
                }
            }
            else if (season == "Winter")
            {
                rent = 2600;
                if (fishermen <= 6)
                {
                    discount = 0.1;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 7 && fishermen <= 11)
                {
                    discount = 0.15;
                    totalCost = rent - rent * discount;
                }
                else if (fishermen >= 12)
                {
                    discount = 0.25;
                    totalCost = rent - rent * discount;
                }
            }
            if (season != "Autumn" && fishermen % 2 == 0)
            {
                discount = 0.05;
                totalCost -= totalCost * discount;
            }
            if (budget >= totalCost)
            {
                double moneyLeft = budget - totalCost;
                Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
            }
            else
            {
                double shortage = totalCost - budget;
                Console.WriteLine($"Not enough money! You need {shortage:f2} leva.");
            }
        }
    }
}
