using System.ComponentModel.Design;

namespace _01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int nodesNum = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesNum];
            visited = new bool[nodesNum];

            for (int node = 0; node < nodesNum; node++)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    List<int> children = input
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            for (int node = 0; node < graph.Length; node++)
            {

                if (visited[node])
                {
                    continue;
                }

                List<int> component = new List<int>();
                DFS(node, component);

                Console.WriteLine($"Connected component: {string.Join(" ", component)}");
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (int child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }
    }
}