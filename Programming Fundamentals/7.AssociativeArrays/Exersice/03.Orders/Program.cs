using System;
using System.Collections.Generic;

namespace _03.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> Orders = new Dictionary<string, Product>();

            while (true)
            {
                string[] productInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (productInfo[0] == "buy")
                {
                    break;
                }

                string currProductName = productInfo[0];
                double currProductPrice = double.Parse(productInfo[1]);
                int currProductQuantity = int.Parse(productInfo[2]);

                Product currProduct = new Product(currProductName, currProductPrice, currProductQuantity);
                if (!Orders.ContainsKey(currProductName))
                {
                    Orders.Add(currProductName, currProduct);
                }
                else
                {
                    Orders[currProductName].Price = currProductPrice;
                    Orders[currProductName].Quantity += currProductQuantity;
                }
            }

            foreach (var product in Orders)
            {
                Console.WriteLine($"{product.Key} -> {product.Value.Price * product.Value.Quantity:F2}");
            }
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
