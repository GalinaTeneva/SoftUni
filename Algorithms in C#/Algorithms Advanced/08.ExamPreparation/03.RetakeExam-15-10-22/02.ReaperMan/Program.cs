using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _02.ReaperMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int blocsCount = int.Parse(Console.ReadLine());
            int pathsCount = int.Parse(Console.ReadLine());

            int[] startAndEnd = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = startAndEnd[0];
            int end = startAndEnd[1];

            Dictionary<int, Dictionary<int, int>> map = ReadMap(blocsCount, pathsCount);

            double[] distance = new double[blocsCount];
            int[] parent = new int[blocsCount];

            for (int i = 0; i < blocsCount; i++)
            {
                distance[i] = double.PositiveInfinity;
                parent[i] = -1;
            }

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));

            bag.Add(start);
            distance[start] = 0;

            while (bag.Count > 0)
            {
                int minBlock = bag.RemoveFirst();

                if (minBlock == end)
                {
                    break;
                }

                foreach (var item in map[minBlock])
                {
                    if (double.IsPositiveInfinity(distance[item.Key]))
                    {
                        bag.Add(item.Key);
                    }

                    double newDistance = distance[minBlock] + item.Value;

                    if (newDistance < distance[item.Key])
                    {
                        distance[item.Key] = newDistance;
                        parent[item.Key] = minBlock;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => distance[f].CompareTo(distance[s])));
                    }
                }
            }

            Stack<int> path = new Stack<int>();

            int block = end;

            while (parent[block] != -1)
            {
                path.Push(block);
                block = parent[block];
            }

            path.Push(start);

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[end]);
        }

        private static Dictionary<int, Dictionary<int, int>> ReadMap(int nodes, int edges)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new Dictionary<int, int>();
            }

            for (int i = 0; i < edges; i++)
            {
                int[] pathInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int from = pathInfo[0];
                int to = pathInfo[1];
                int distance = pathInfo[2];

                graph[from][to] = distance;
            }

            return graph;
        }
    }
}