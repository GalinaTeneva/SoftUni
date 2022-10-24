using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<product>[a-zA-Z]+)<<(?<price>([0-9]+\.?)([0-9]+)?)!(?<quantity>\d+)";
            Regex regex = new Regex(pattern);
            List<Product> matchedFurnitures = new List<Product>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }

                Match match = regex.Match(input);
                bool isMatchedFurniture = regex.IsMatch(input);
                if (isMatchedFurniture)
                {
                    string product = match.Groups["product"].ToString();
                    double price = double.Parse(match.Groups["price"].ToString());
                    int quantity = int.Parse(match.Groups["quantity"].ToString());

                    matchedFurnitures.Add(new Product(product, price, quantity));
                }
            }

            Console.WriteLine("Bought furniture:");

            double spendMoney = 0;
            foreach (Product furniture in matchedFurnitures)
            {
                Console.WriteLine(furniture.Name);

                spendMoney += furniture.Price * furniture.Quantity;
            }

            Console.WriteLine($"Total money spend: {spendMoney:F2}");
        }
    }

    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product (string name, double price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
