using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _03.EShop
{
    public class Item
    {
        public string ItemName { get; set; }

        public int ItemWeight { get; set; }

        public int ItemValue { get; set; }
    }

    internal class Program
    {
        public static List<Item> items;
        //public static Dictionary<string,HashSet<Item>> collections;
        public static Dictionary<string, HashSet<Item>> itemsGraph;
        public static List<HashSet<Item>> collectionsList;

        public static Dictionary<string, bool> visited;

        static void Main(string[] args)
        {
            //collections = new Dictionary<string, HashSet<Item>>();
            items = new List<Item>();
            collectionsList = new List<HashSet<Item>>();
            itemsGraph = new Dictionary<string, HashSet<Item>>();

            int itemsCount = int.Parse(Console.ReadLine());

            ReadItems(itemsCount);
            ReadItemPairs(itemsCount);

            visited = new Dictionary<string, bool>();
            for (int i = 0; i < items.Count; i++)
            {
                Item curr = items[i];

                visited[curr.ItemName] = false;
            }

            DefineItemsCombinations();

            int maxCapacity = int.Parse(Console.ReadLine());

            int[,] dp = new int[collectionsList.Count + 1, maxCapacity + 1];
            bool[,] used = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var collection = collectionsList[row - 1];

                int collectionWeight = collection.Sum(i => i.ItemWeight);
                int collectionValue = collection.Sum(i => i.ItemValue);

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    int excluding = dp[row - 1, capacity];

                    if (collectionWeight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    int including = collectionValue + dp[row - 1, capacity - collectionWeight];

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
            SortedSet<string> takenItems = new SortedSet<string>();

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currCapacity])
                {
                    continue;
                }

                var collection = collectionsList[row - 1];
                int takenCapacity = 0;
                foreach (var item in collection)
                {
                    takenItems.Add(item.ItemName);
                    takenCapacity += item.ItemWeight;
                }

                currCapacity -= takenCapacity;

                if (currCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, takenItems));
        }

        private static void ReadItemPairs(int itemsCount)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                itemsGraph[items[i].ItemName] = new HashSet<Item>();
            }

            int pairsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairsCount; i++)
            {
                string[] pairParts = Console.ReadLine().Split();

                Item firstItem = items.FirstOrDefault(i => i.ItemName == pairParts[0]);
                Item secondItem = items.FirstOrDefault(i => i.ItemName == pairParts[1]);

                itemsGraph[firstItem.ItemName].Add(secondItem);
                itemsGraph[secondItem.ItemName].Add(firstItem);
            }
        }

        private static void ReadItems(int itemsCount)
        {
            for (int i = 0; i < itemsCount; i++)
            {
                string[] itemInfo = Console.ReadLine().Split();

                items.Add(new Item
                {
                    ItemName = itemInfo[0],
                    ItemWeight = int.Parse(itemInfo[1]),
                    ItemValue = int.Parse(itemInfo[2])
                });
            }
        }

        private static void DefineItemsCombinations()
        {
            foreach (var pair in itemsGraph)
            {
                if (visited[pair.Key])
                {
                    continue;
                }

                HashSet<Item> component = new HashSet<Item>();
                DFS(pair.Key, component);

                collectionsList.Add(component);
            }
        }

        private static void DFS(string itemName, HashSet<Item> component)
        {
            if (visited[itemName])
            {
                return;
            }

            visited[itemName] = true;

            Item item = items.FirstOrDefault(i => i.ItemName == itemName);

            foreach (var child in itemsGraph[itemName])
            {
                DFS(child.ItemName, component);
            }

            component.Add(item);
        }
    }
}