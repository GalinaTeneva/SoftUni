using System;

namespace _03.New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double rosePrice = 5;
            double dahliaPrice = 3.80;
            double tulipPrice = 2.80;
            double narcissusPrice = 3;
            double gladiolusPrice = 2.50;

            double totalPrice = 0;

            switch (flower)
            {
                case "Roses":
                    totalPrice = rosePrice * flowerCount;
                    if (flowerCount > 80)
                    {
                       double discount = 0.1;
                        totalPrice -= (totalPrice * discount);
                    }
                    break;
                case "Dahlias":
                    totalPrice = dahliaPrice * flowerCount;
                    if (flowerCount > 90)
                    {
                        double discount = 0.15;
                        totalPrice -= (totalPrice * discount);
                    }
                    break;
                case "Tulips":
                    totalPrice = tulipPrice * flowerCount;
                    if (flowerCount > 80)
                    {
                        double discount = 0.15;
                        totalPrice -= (totalPrice * discount);
                    }
                    break;
                case "Narcissus":
                    totalPrice = narcissusPrice * flowerCount;
                    if (flowerCount < 120)
                    {
                        double costRaise = 0.15;
                        totalPrice += (totalPrice * costRaise);
                    }
                    break;
                case "Gladiolus":
                    totalPrice = gladiolusPrice * flowerCount;
                    if (flowerCount < 80)
                    {
                        double costRaise = 0.2;
                        totalPrice += (totalPrice * costRaise);
                    }
                    break;
            }

            if (budget >= totalPrice)
            {
                double moneyLeft = budget - totalPrice;
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flower} and {moneyLeft:f2} leva left.");
            }
            else if (!(budget >= totalPrice))
            {
                double moneyShortage = totalPrice - budget;
                Console.WriteLine($"Not enough money, you need {moneyShortage:f2} leva more.");
            }
        }
    }
}
