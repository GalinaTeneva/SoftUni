using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RodCutting
{
    internal class Program
    {
        private static int[] memo;
        private static int[] prev;

        static void Main(string[] args)
        {
            int[] price = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            memo = new int[price.Length];
            prev = new int[price.Length];

            int length = int.Parse(Console.ReadLine());

            int bestPrice = CutRod(price, length);

            List<int> parts = new List<int>();

            while (length != 0)
            {
                int currPrev = prev[length];
                parts.Add(currPrev);
                length -= currPrev;
            }

            Console.WriteLine(bestPrice);
            Console.WriteLine(string.Join(" ", parts));
        }

        private static int CutRod(int[] price, int length)
        {
            if (length == 0)
            {
                return 0;
            }

            if (memo[length] != 0)
            {
                return memo[length];
            }

            int bestPrice = price[length];
            int bestCombo = length;

            for (int i = 1; i < length; i++)
            {
                int currPrice = price[i] + CutRod(price, length - i);

                if (currPrice > bestPrice)
                {
                    bestPrice = currPrice;
                    bestCombo = i;
                }
            }

            memo[length] = bestPrice;
            prev[length] = bestCombo;

            return bestPrice;
        }
    }
}