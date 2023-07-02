using System.Security.Cryptography;

namespace _02.TopologicalSorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            int nodesNum = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesNum);

            dependencies = ExtractDependencie(graph);

            List<string> sorted = new List<string>();

            while (dependencies.Count > 0)
            {
                var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;

                if (nodeToRemove == null)
                {
                    break;
                }

                dependencies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);

                foreach (string child in graph[nodeToRemove])
                {
                    dependencies[child] -= 1;
                }
            }

            if (dependencies.Count == 0)
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
            }
            else
            {
                Console.WriteLine("Invalid topological sorting");
            }
        }

        private static Dictionary<string, int> ExtractDependencie(Dictionary<string, List<string>> graph)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                string node = kvp.Key;
                List<string> children = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result[node] = 0;
                }

                foreach (string child in children)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child] += 1;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int nodes)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            for (int node = 0; node < nodes; node++)
            {
                string[] currNodeParts = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .Select(e => e.Trim())
                    .ToArray();

                string currNode = currNodeParts[0];

                if (currNodeParts.Length == 1)
                {
                    result[currNode] = new List<string>();
                }
                else
                {
                    List<string> children = currNodeParts[1]
                    .Split(", ")
                    .ToList();

                    result[currNode] = children;
                }
            }

            return result;
        }
    }
}