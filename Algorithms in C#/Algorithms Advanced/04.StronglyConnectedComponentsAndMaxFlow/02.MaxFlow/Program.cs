using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MaxFlow
{
    internal class Program
    {
        private static int[,] graph;
        private static int[] parent;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());

            graph = new int[nodes, nodes];

            for (int n = 0; n < nodes; n++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < nodes; c++)
                {
                    graph[n, c] = line[c];
                }
            }

            int source = int.Parse(Console.ReadLine());
            int target = int.Parse(Console.ReadLine());

            parent = new int[nodes];
            Array.Fill(parent, -1);

            int maxFlow = 0;

            while (BFS(source, target))
            {
                int minFlow = GetMinFlow(target);
                ApplyFlow(target, minFlow);

                maxFlow += minFlow;
            }

            Console.WriteLine($"Max flow = {maxFlow}");
        }

        private static void ApplyFlow(int node, int flow)
        {
            while (parent[node] != -1)
            {
                int prev = parent[node];
                graph[prev, node] -= flow;
                node = prev;
            }
        }

        private static int GetMinFlow(int target)
        {
            int minFlow = int.MaxValue;

            int node = target;
            while (parent[node] != -1)
            {
                int prev = parent[node];
                int flow = graph[prev, node];

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
            bool[] visited = new bool[graph.GetLength(0)];
            visited[source] = true;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child] > 0)
                    {
                        visited[child] = true;
                        queue.Enqueue(child);
                        parent[child] = node;
                    }
                }
            }

            return visited[target];
        }
    }
}