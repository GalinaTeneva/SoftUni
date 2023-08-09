using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.RoadTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] itemsValues = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[] itemsSpaces = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int trunkCapacity = int.Parse(Console.ReadLine());

            int[,] dp = new int[itemsSpaces.Length + 1, trunkCapacity + 1];
            bool[,] used = new bool[itemsSpaces.Length + 1, trunkCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                int itemIdx = row - 1;

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[row - 1, capacity];

                    if (itemsSpaces[itemIdx] > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    int including = itemsValues[itemIdx] + dp[row - 1, capacity - itemsSpaces[itemIdx]];

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        used[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            int currCapacity = trunkCapacity;
            int totalValue = 0;

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currCapacity])
                {
                    continue;
                }

                int itemIdx = row - 1;
                totalValue += itemsValues[itemIdx];
                currCapacity -= itemsSpaces[itemIdx];

                if (currCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Maximum value: {totalValue}");
        }
    }
}