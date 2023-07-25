using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.StronglyConnectedComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            List<int>[] graph = new List<int>[nodes];
            List<int>[] reverseGraph = new List<int>[nodes];

            for (int n = 0; n < nodes; n++)
            {
                graph[n] = new List<int>();
                reverseGraph[n] = new List<int>();
            }

            for (int i = 0; i < lines; i++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = line[0];

                for (int j = 0; j < line.Length; j++)
                {
                    int child = line[j];

                    graph[node].Add(child);
                    reverseGraph[child].Add(node);
                }
            }

            bool[] visited = new bool[graph.Length];
            Stack<int> sorted = new Stack<int> ();

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, graph, visited, sorted);
            }

            visited = new bool[graph.Length];

            Console.WriteLine("Strongly Connected Components:"); 

            while (sorted.Count > 0)
            {
                int node = sorted.Pop();
                Stack<int> component = new Stack<int>();

                if (visited[node])
                {
                    continue;
                }

                DFS(node, reverseGraph, visited, component);

                Console.WriteLine($"{{{string.Join(", ", component)}}}");
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