using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace _04.BigTrip
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

            var edgesByNode = ReadGraph(edgesNum);

            int source = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            double[] distance = new double[nodesNum + 1];
            int[] prev = new int[nodesNum + 1];

            for (int n = 1; n < nodesNum; n++)
            {
                distance[n] = double.NegativeInfinity;
                prev[n] = -1;
            }

            distance[source] = 0;

            var sortedNodes = TopologicalSort(edgesByNode);

            while (sortedNodes.Count > 0)
            {
                int node = sortedNodes.Pop();

                foreach  (Edge edge in edgesByNode[node])
                {
                    double newDistance = distance[node] + edge.Weight;

                    if (distance[edge.Second] < newDistance)
                    {
                        distance[edge.Second] = newDistance;
                        prev[edge.Second] = edge.First;
                    }
                }
            }

            Console.WriteLine(distance[destination]);

            var path = FindPath(destination, prev);
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> FindPath(int node, int[] parents)
        {
            Stack<int> result = new Stack<int>();

            while (node != -1)
            {
                result.Push(node);
                node = parents[node]; 
            }

            return result;
        }

        private static Stack<int> TopologicalSort(Dictionary<int, List<Edge>> graph)
        {
            Stack<int> result = new Stack<int>();
            bool[] visited = new bool[graph.Count + 1];

            foreach (int node in graph.Keys)
            {
                DFS(node,graph, visited, result);
            }

            return result;
        }

        private static void DFS(int node,Dictionary<int, List<Edge>> graph, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (Edge edge in graph[node])
            {
                DFS(edge.Second, graph, visited, result);
            }

            result.Push(node);
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int edgesNum)
        {
            var graph = new Dictionary<int, List<Edge>>();

            for (int e = 0; e < edgesNum; e++)
            {
                int[] currEdgeInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = currEdgeInfo[0];
                int secondNode = currEdgeInfo[1];
                int weight = currEdgeInfo[2];

                if (!graph.ContainsKey(firstNode))
                {
                    graph[firstNode] = new List<Edge>();
                }

                if (!graph.ContainsKey(secondNode))
                {
                    graph[secondNode] = new List<Edge>();
                }

                Edge edge = new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                };

                graph[firstNode].Add(edge);
            }

            return graph;
        }
    }
}