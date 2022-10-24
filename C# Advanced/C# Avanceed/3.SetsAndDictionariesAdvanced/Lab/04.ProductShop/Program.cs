using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> productPricesByShop = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    foreach (var s in productPricesByShop.OrderBy(s => s.Key))
                    {
                        Console.WriteLine($"{s.Key}->");

                        foreach (var p in s.Value)
                        {
                            Console.WriteLine($"Product: {p.Key}, Price: {p.Value}");
                        }
                    }

                    break;
                }

                string[] inputTokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = inputTokens[0];
                string product = inputTokens[1];
                double price = double.Parse(inputTokens[2]);

                if (!productPricesByShop.ContainsKey(shop))
                {
                    productPricesByShop.Add(shop, new Dictionary<string, double>());

                }
                
                productPricesByShop[shop][product] = price;
            }
        }
    }
}
