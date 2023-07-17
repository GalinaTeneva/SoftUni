using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.KruskalsAlgorithm
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static List<Edge> edges;
        private static List<Edge> forest;
        private static int[] parent;

        static void Main(string[] args)
        {
            edges = new List<Edge>();
            forest = new List<Edge>();

            int count = int.Parse(Console.ReadLine());

            int maxNode = -1;

            for (int i = 0; i < count; i++)
            {
                var edgeArgs = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeArgs[0];
                int secondNode = edgeArgs[1];

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }

                if (secondNode > maxNode)
                {
                    maxNode = secondNode;
                }

                Edge edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeArgs[2]
                };

                edges.Add(edge);
            }

            parent = new int[maxNode + 1];
            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            var sortedEdges = edges
                .OrderBy(e => e.Weight)
                .ToArray();

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }

            foreach (var edge in forest)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static int FindRoot(int node)
        {
            while (node != parent[node])
            {
                node = parent[node];
            }
            
            return node;
        }
    }
}
    