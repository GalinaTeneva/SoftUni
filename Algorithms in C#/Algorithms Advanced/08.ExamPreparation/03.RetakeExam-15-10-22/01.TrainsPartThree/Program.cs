using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrainsPartThree
{
    public class Tube
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Throughput { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, Dictionary<int, int>> system;
        private static int[] parent;

        static void Main(string[] args)
        {
            int splitsCount = int.Parse(Console.ReadLine());
            int tubesCount = int.Parse(Console.ReadLine());
            int[] sourceAndInjector = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int source = sourceAndInjector[0];
            int injector = sourceAndInjector[1];

            system = ReadGraph(splitsCount, tubesCount);

            parent = new int[splitsCount];
            for (int i = 0; i < splitsCount; i++)
            {
                parent[i] = -1;
            }

            int maxFuel = 0;

            while (BFS(source, injector))
            {
                int minFlow = GetMinFlow(injector);
                ApplyFlow(injector, minFlow);
                maxFuel += minFlow;
            }

            Console.WriteLine(maxFuel);
        }

        private static Dictionary<int, Dictionary<int, int>> ReadGraph(int splitsCount, int tubesCount)
        {
            Dictionary<int, Dictionary<int, int>> graph = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < splitsCount + 1; i++)
            {
                graph.Add(i, new Dictionary<int, int>());
            }

            for (int i = 0; i < tubesCount; i++)
            {
                int[] tubeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = tubeInfo[0];
                int to = tubeInfo[1];
                int length = tubeInfo[2];

                graph[from][to] = length;
            }

            return graph;
        }

        private static void ApplyFlow(int node, int flow)
        {
            while (parent[node] != -1)
            {
                int prev = parent[node];
                system[prev][node] -= flow;
                node = prev;
            }
        }

        private static int GetMinFlow(int node)
        {
            int minFlow = int.MaxValue;

            while (parent[node] != -1)
            {
                int prev = parent[node];
                int flow = system[prev][node];

                if (flow < minFlow)
                {
                    minFlow = flow;
                }
                node = prev;
            }

            return minFlow;
        }

        private static bool BFS(int source, int target)
        {
            bool[] visited = new bool[system.Count];

            visited[source] = true;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                foreach (var child in system[node])
                {
                    if (!visited[child.Key] && child.Value > 0)
                    {
                        visited[child.Key] = true;
                        queue.Enqueue(child.Key);
                        parent[child.Key] = node;
                    }
                }
            }

            return visited[target];
        }
    }
}