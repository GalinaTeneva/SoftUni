using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _01.BellmanFord
{
    public class Edge
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            List<Edge> graph = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                int[] edgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                graph.Add(new Edge
                {
                    From = edgeInfo[0],
                    To = edgeInfo[1],
                    Weight = edgeInfo[2]
                });
            }

            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            double[] distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);

            distance[start] = 0;

            int[] prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            for (int i = 0; i < nodes - 1; i++)
            {
                bool updated = false;

                foreach (Edge edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    double newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (Edge edge in graph)
            {
                double newDistance = distance[edge.From] + edge.Weight;

                if (newDistance < distance[edge.To])
                {
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }

            Stack<int> path = new Stack<int>();
            int node = end;

            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distance[end]);
        }

    }
}
