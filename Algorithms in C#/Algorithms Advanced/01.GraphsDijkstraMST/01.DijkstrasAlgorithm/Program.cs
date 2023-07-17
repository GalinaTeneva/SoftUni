using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.DijkstrasAlgorithm
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parent;

        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            int edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                int[] edgeTokens = Console.ReadLine()
                    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                int firstNode = edgeTokens[0];
                int secondNode = edgeTokens[1];

                var currEdge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeTokens[2]
                };


                if (!edgesByNode.ContainsKey(firstNode))
                {
                    edgesByNode.Add(firstNode, new List<Edge>());
                }

                if (!edgesByNode.ContainsKey(secondNode))
                {
                    edgesByNode.Add(secondNode, new List<Edge>());
                }

                edgesByNode[firstNode].Add(currEdge);
                edgesByNode[secondNode].Add(currEdge);
            }

            int biggestNode = edgesByNode.Keys.Max();

            distance = new double[biggestNode + 1];

            for (int n = 0; n < distance.Length; n++)
            {
                distance[n] = double.PositiveInfinity;
            }

            parent = new int[biggestNode + 1];
            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = -1;
            }

            int startNode = int.Parse(Console.ReadLine());
            int endNode = int.Parse(Console.ReadLine());

            distance[startNode] = 0;

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
            bag.Add(startNode);

            while (bag.Count > 0)
            {
                int minNode = bag.RemoveFirst();

                if (double.IsPositiveInfinity(minNode))
                {
                    break;
                }

                if (minNode == endNode)
                {
                    break;
                }

                foreach (var edge in edgesByNode[minNode])
                {
                    int otherNode = edge.First == minNode ? edge.Second : edge.First;

                    if (double.IsPositiveInfinity(distance[otherNode]))
                    {
                        bag.Add(otherNode);
                    }

                    double newDistance = distance[minNode] + edge.Weight;

                    if (newDistance < distance[otherNode])
                    {
                        distance[otherNode] = newDistance;
                        parent[otherNode] = minNode;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => (int)(distance[f] - distance[s])));
                    }

                }
            }

            if (double.IsPositiveInfinity(distance[endNode]))
            {
                Console.WriteLine("There is no such path.");
            }
            else
            {
                Console.WriteLine(distance[endNode]);

                int node = endNode;
                var path = new Stack<int>();

                while (node != -1)
                {
                    path.Push(node);
                    node = parent[node];
                }

                Console.WriteLine(string.Join(" ", path));
            }
        }
    }
}