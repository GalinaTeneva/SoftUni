using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _01.MostReliablePath
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        public static Dictionary<int, List<Edge>> edgesByNode;

        static void Main(string[] args)
        {
            edgesByNode = ReadGraph();

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distance = new double[edgesByNode.Count];
            int[] prev = new int[edgesByNode.Count];

            for (int i = 0; i < edgesByNode.Count; i++)
            {
                distance[i] = double.NegativeInfinity;
                prev[i] = -1;
            }

            distance[source] = 100;

            var bag = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(distance[s] - distance[f])));
            bag.Add(source);

            while (bag.Count > 0)
            {
                int currNode = bag.RemoveFirst();

                if (currNode == destination)
                {
                    break;
                }

                foreach (var edge in edgesByNode[currNode])
                {
                    int child = edge.First == currNode ? edge.Second : edge.First;

                    if (double.IsNegativeInfinity(distance[child]))
                    {
                        bag.Add(child);
                    }

                    double newDistance = distance[currNode] * edge.Weight / 100.0;

                    if (newDistance > distance[child])
                    {
                        distance[child] = newDistance;
                        prev[child] = currNode;

                        bag = new OrderedBag<int>(bag, Comparer<int>.Create((f, s) => (int)(distance[s] - distance[f])));
                    }
                }
            }

            Console.WriteLine($"Most reliable path reliability: {distance[destination]:F2}%");

            var path = new Stack<int>();
            int node = destination;

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            Console.WriteLine(string.Join(" -> ", path));
        }

        private static Dictionary<int, List<Edge>> ReadGraph()
        {
            int nodesNum = int.Parse(Console.ReadLine());
            int edgesNum = int.Parse(Console.ReadLine());

            var result = new Dictionary<int, List<Edge>>();

            for (int e = 0; e < edgesNum; e++)
            {
                int[] edgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int first = edgeInfo[0];
                int second = edgeInfo[1];

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
                    Weight = edgeInfo[2]
                };

                result[first].Add(edge);
                result[second].Add(edge);
            }

            return result;
        }
    }
}