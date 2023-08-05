using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _02.Knapsack
{
    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            List<Item> items = new List<Item>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] itemInfo = line.Split();

                items.Add(new Item
                {
                    Name = itemInfo[0],
                    Weight = int.Parse(itemInfo[1]),
                    Value = int.Parse(itemInfo[2])
                });
            }

            int[,] dp = new int[items.Count + 1, maxCapacity + 1];
            bool[,] used = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                int itemIdx = row - 1;
                Item item = items[itemIdx];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[row - 1, capacity];

                    if (item.Weight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    int including = item.Value + dp[row - 1, capacity - item.Weight];

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

            int currCapacity = maxCapacity;
            int totalWeight = 0;
            SortedSet<string> usedItems = new SortedSet<string>();

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currCapacity])
                {
                    continue;
                }

                Item item = items[row - 1];
                totalWeight += item.Weight;
                currCapacity -= item.Weight;
                usedItems.Add(item.Name);

                if (currCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {dp[items.Count, maxCapacity]}");
            Console.WriteLine(string.Join(Environment.NewLine, usedItems));
        }
    }
}