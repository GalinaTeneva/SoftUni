using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Collections;

namespace _02.CryptoExchange
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;

        static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();

            int pairs = int.Parse(Console.ReadLine());

            for (int i = 0; i < pairs; i++)
            {
                string[] edge = Console.ReadLine().Split(" - ");

                string from = edge[0];
                string to = edge[1];

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<string>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new List<string>());
                }

                graph[from].Add(to);
                graph[to].Add(from);
            }

            string[] tradePrams = Console.ReadLine().Split(" -> ");
            string start = tradePrams[0];
            string end = tradePrams[1];

            int result = CalcOperations(start, end);
            Console.WriteLine(result);
        }

        private static int CalcOperations(string start, string end)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            HashSet<string> visited = new HashSet<string> { start };
            Dictionary<string, string> parent = new Dictionary<string, string> { { start, string.Empty } };

            while (queue.Count > 0)
            {
                string currNode = queue.Dequeue();

                if (currNode == end)
                {
                    return GetSteps(parent, end);
                }

                foreach (string child in graph[currNode])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = currNode;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<string, string> parent, string end)
        {
            int steps = 0;

            string node = end;

            while (!string.IsNullOrEmpty(node))
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}