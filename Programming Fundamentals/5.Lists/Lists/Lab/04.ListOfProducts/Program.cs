using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            int productsCount = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int currentInput = 1; currentInput <= productsCount; currentInput++)
            {
                products.Add(Console.ReadLine());
            }

            products.Sort();

            for (int currentProduct = 1; currentProduct <= productsCount; currentProduct++)
            {
                Console.WriteLine($"{currentProduct}.{products[currentProduct - 1]}");
            }
        }
    }
}
