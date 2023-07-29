using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;

namespace _01.ElectricalSubstationNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            List<int>[] reverseGraph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                graph[node] = new List<int>();
                reverseGraph[node] = new List<int>();
            }

            for (int line = 0; line < lines; line++)
            {
                int[] lineInfo = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = lineInfo[0];

                for (int i = 1; i < lineInfo.Length; i++)
                {
                    int child = lineInfo[i];

                    graph[node].Add(child);
                    reverseGraph[child].Add(node);
                }
            }

            bool[] visited = new bool[graph.Length];
            Stack<int> sorted = new Stack<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[graph.Length];

            while (sorted.Count > 0)
            {
                int node = sorted.Pop();

                Stack<int> components = new Stack<int>();

                if (visited[node])
                {
                    continue;
                }

                DFS(node, reverseGraph, visited, components);

                Console.WriteLine(string.Join(", ", components));
            }
        }

        private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph[node])
            {
                DFS(child, graph, visited, result);
            }

            result.Push(node);
        }
    }
}