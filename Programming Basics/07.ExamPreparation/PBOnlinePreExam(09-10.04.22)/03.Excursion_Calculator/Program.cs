using System;

namespace _03.Excursion_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double price = 0;
            if (people <= 5)
            {
                switch (season)
                {
                    case "spring":
                        price = 50.00;
                        break;
                    case "summer":
                        price = 48.50;
                        break;
                    case "autumn":
                        price = 60.00;
                        break;
                    case "winter":
                        price = 86.00;
                        break;
                }
            }
            else
            {
                switch (season)
                {
                    case "spring":
                        price = 48.00;
                        break;
                    case "summer":
                        price = 45.00;
                        break;
                    case "autumn":
                        price = 49.50;
                        break;
                    case "winter":
                        price = 85.00;
                        break;
                }
            }

            double totalPrice = people * price;

            if (season == "summer")
            {
                totalPrice -= totalPrice * 0.15;
            }
            else if (season == "winter")
            {
                totalPrice += totalPrice * 0.08;
            }

            Console.WriteLine($"{totalPrice:F2} leva.");
        }
    }
}
