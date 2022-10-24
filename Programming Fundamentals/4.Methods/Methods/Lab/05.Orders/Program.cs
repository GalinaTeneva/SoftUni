using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            const double CoffeePrice = 1.50;
            const double WaterPrice = 1.00;
            const double CokePrice = 1.40;
            const double SnacksPrice = 2.00;

            double productPrice = 0;
            switch (product)
            {
                case "coffee":
                    productPrice = CoffeePrice;
                    TotalPrice(productPrice, quantity);
                    break;
                case "water":
                    productPrice = WaterPrice;
                    TotalPrice(productPrice, quantity);
                    break;
                case "coke":
                    productPrice = CokePrice;
                    TotalPrice(productPrice, quantity);
                    break;
                case "snacks":
                    productPrice = SnacksPrice;
                    TotalPrice(productPrice, quantity);
                    break;
            }
        }

        static void TotalPrice(double productPrice, int productQuantity)
        {
            double result = productPrice * productQuantity;
            Console.WriteLine($"{result:F2}");
        }
    }
}
