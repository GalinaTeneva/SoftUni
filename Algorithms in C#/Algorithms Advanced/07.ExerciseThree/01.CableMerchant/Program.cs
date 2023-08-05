using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CableMerchant
{
    internal class Program
    {
        private static int[] maxPrices;

        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> originalPrices = new List<int>() { 0 };
            originalPrices.AddRange(prices);

            int connectorPrice = int.Parse(Console.ReadLine());

            maxPrices = new int[originalPrices.Count];

            CutCable(originalPrices, originalPrices.Count - 1, connectorPrice);

            Console.WriteLine(string.Join(" ", maxPrices.Skip(1)));
        }

        private static int CutCable(List<int> prices, int length, int connectorPrice)
        {
            if (length == 0)
            {
                return 0;
            }

            if (maxPrices[length] != 0)
            {
                return maxPrices[length];
            }

            int bestPrice = prices[length];

            for (int i = 1; i < length; i++)
            {
                int currPrice = prices[i] + CutCable(prices, length - i, connectorPrice) - 2 * connectorPrice;

                if (currPrice > bestPrice)
                {
                    bestPrice = currPrice;
                }
            }

            maxPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}