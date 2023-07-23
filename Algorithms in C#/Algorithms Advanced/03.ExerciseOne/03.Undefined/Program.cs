using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Undefined
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodesNum = int.Parse(Console.ReadLine());
            int edgesNum = int.Parse(Console.ReadLine());

            List<Edge> graph = ReadGraph(edgesNum);

            double[] distance = new double[nodesNum + 1];
            Array.Fill(distance, double.PositiveInfinity);

            int[] prev = new int[nodesNum + 1];
            Array.Fill(prev, -1);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            distance[source] = 0;

            for (int n = 0; n < nodesNum - 1; n++)
            {
                bool isUpdated = false;

                foreach (Edge edge in graph)
                {
                    var newDistance = distance[edge.First] + edge.Weight;

                    if (!double.IsPositiveInfinity(distance[edge.First]) &&
                        (newDistance < distance[edge.Second]))
                    {
                        distance[edge.Second] = newDistance;
                        prev[edge.Second] = edge.First;
                        isUpdated = true;
                    }
                }

                if (!isUpdated)
                {
                    break;
                }
            }

            foreach (Edge edge in graph)
            {
                var newDistance = distance[edge.First] + edge.Weight;

                if (newDistance < distance[edge.Second])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = FindPath(prev, destination);
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[destination]);
        }

        private static Stack<int> FindPath(int[] prev, int destination)
        {
            var path = new Stack<int>();

            int node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            return path;
        }

        private static List<Edge> ReadGraph(int edges)
        {
            List<Edge> graph = new List<Edge>();

            for (int e = 0; e < edges; e++)
            {
                int[] currEdgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge()
                {
                    First = currEdgeInfo[0],
                    Second = currEdgeInfo[1],
                    Weight = currEdgeInfo[2]
                });
            }

            return graph;
        }
    }
}