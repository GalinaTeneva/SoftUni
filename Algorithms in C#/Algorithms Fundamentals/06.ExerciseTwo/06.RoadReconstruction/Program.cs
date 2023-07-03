using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace _06.RoadReconstruction
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public override string ToString()
        {
            return $"{First} {Second}";
        }
    }

    internal class Program
    {
        private static List<int>[] graph;
        private static List<Edge> edges;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int nodesNum = int.Parse(Console.ReadLine());
            int edgesNum = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesNum];
            edges = new List<Edge>();

            for (int i = 0; i < nodesNum; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edgesNum; i++)
            {
                int[] edgeParts = Console.ReadLine()
                    .Split(" - ")
                    .Select(int.Parse)
                    .ToArray();

                int firstNode = edgeParts[0];
                int secondNode = edgeParts[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);

                edges.Add(new Edge { First = firstNode, Second = secondNode });
            }

            Console.WriteLine($"Important streets: ");

            foreach (Edge edge in edges)
            {
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                visited = new bool[graph.Length];
                DFS(0);

                if (visited.Contains(false))
                {
                    Edge newEdge = new Edge
                    {
                        First = Math.Min(edge.First, edge.Second),
                        Second = Math.Max(edge.First, edge.Second)
                    };

                    Console.WriteLine(newEdge);
                }

                graph[edge.First].Add(edge.Second);
                graph[edge.Second].Add(edge.First);
            }
        }

        private static void DFS(int node)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph[node])
            {
                DFS(child);
            }
        }
    }
}