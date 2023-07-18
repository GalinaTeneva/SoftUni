using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.LongestPath
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;

        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            for (int e = 0; e < edges; e++)
            {
                int[] currEdgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = currEdgeInfo[0];
                int to = currEdgeInfo[1];

                if (!edgesByNode.ContainsKey(from))
                {
                    edgesByNode.Add(from, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(to))
                {
                    edgesByNode.Add(to, new List<Edge>());
                }

                edgesByNode[from].Add(new Edge
                {
                    From = from,
                    To = to,
                    Weight = currEdgeInfo[2]
                });
            }

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            var distances = new double[nodes + 1];
            Array.Fill(distances, double.NegativeInfinity);
            distances[start] = 0;

            var prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            var sortedNodes = TopologicalSorting();

            while (sortedNodes.Count > 0)
            {
                int node = sortedNodes.Pop();

                foreach (Edge edge in edgesByNode[node])
                {
                    double newDistance = distances[edge.From] + edge.Weight;

                    if (newDistance > distances[edge.To])
                    {
                        distances[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                    }
                }
            }

            Console.WriteLine(distances[end]);

            var path = new Stack<int>();
            var currNode = end;

            while (currNode != -1)
            {
                path.Push(currNode);
                currNode = prev[currNode];
            }

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> TopologicalSorting()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in edgesByNode.Keys)
            {
                DFS(node, visited, result);
            }

            return result;
        }

        private static void DFS(int node, HashSet<int> visited, Stack<int> result)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var edge in edgesByNode[node])
            {
                DFS(edge.To, visited, result);
            }

            result.Push(node);
        }
    }
}