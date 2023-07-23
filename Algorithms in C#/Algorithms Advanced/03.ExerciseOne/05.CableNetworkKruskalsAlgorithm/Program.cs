using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CableNetworkKruskalsAlgorithm
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        public static HashSet<int> connectedNodes;
        public static List<Edge> nonConnectedEdges;
        public static List<Edge> connectedEdges;
        public static int[] parent;
        public static Dictionary<int, List<Edge>> graph;

        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            connectedNodes = new HashSet<int>();
            nonConnectedEdges = new List<Edge>();
            connectedEdges = new List<Edge>();
            graph = ReadGraph(edges);

            parent = new int[graph.Count];
            for (int n = 0; n < parent.Length; n++)
            {
                parent[n] = n;
            }

            foreach (Edge edge in connectedEdges.OrderBy(e => e.Weight))
            {
                int firstNodeRoot = FindRoot(edge.First);
                int secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
            }

            int usedBudget = 0;

            var orderedNonConnectedEdges = nonConnectedEdges.OrderBy(e => e.Weight).ToList();
            int count = orderedNonConnectedEdges.Count;
            for (int i = 0; i < orderedNonConnectedEdges.Count;)
            {
                Edge edge = orderedNonConnectedEdges[i];

                orderedNonConnectedEdges.RemoveAt(i);

                int firstNodeRoot = FindRoot(edge.First);
                int secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                if (!connectedNodes.Contains(edge.First) && !connectedNodes.Contains(edge.Second))
                {
                    orderedNonConnectedEdges.Insert(i + 2, edge);
                    continue;
                }

                if (usedBudget + edge.Weight >= budget)
                {
                    break;
                }

                usedBudget += edge.Weight;

                parent[firstNodeRoot] = secondNodeRoot;

                connectedNodes.Add(edge.First);
                connectedNodes.Add(edge.Second);
            }

            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int FindRoot(int node)
        {
            while (parent[node] != node)
            {
                node = parent[node];
            }

            return node;
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int edges)
        {
            Dictionary<int, List<Edge>> result = new Dictionary<int, List<Edge>>();

            for (int e = 0; e < edges; e++)
            {
                string[] edgeInfo = Console.ReadLine().Split();

                int first = int.Parse(edgeInfo[0]);
                int second = int.Parse(edgeInfo[1]);

                if (!result.ContainsKey(first))
                {
                    result[first] = new List<Edge>();
                }

                if (!result.ContainsKey(second))
                {
                    result[second] = new List<Edge>();
                }

                Edge edge = new Edge
                {
                    First = first,
                    Second = second,
                    Weight = int.Parse(edgeInfo[2])
                };

                result[first].Add(edge);
                result[second].Add(edge);

                if (edgeInfo.Length == 4)
                {
                    connectedNodes.Add(first);
                    connectedNodes.Add(second);
                    connectedEdges.Add(edge);
                }
                else
                {
                    nonConnectedEdges.Add(edge);
                }
            }

            return result;
        }
    }
}