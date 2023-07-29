using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.FindBiConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] parent;
        private static Stack<int> stack;
        private static List<HashSet<int>> components;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int edges = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            visited = new bool[nodes];
            depth = new int[nodes];
            lowpoint = new int[nodes];
            parent = new int[nodes];
            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
                parent[i] = -1;
            }

            for (int e = 0; e < edges; e++)
            {
                int[] edgeNodes = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int firstNode = edgeNodes[0];
                int secondNode = edgeNodes[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                FindArticulationPoint(node, 1);
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoint(int node, int currDepth)
        {
            visited[node] = true;
            depth[node] = currDepth;
            lowpoint[node] = currDepth;

            int childrenCount = 0;

            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;

                    FindArticulationPoint(child, currDepth + 1);

                    childrenCount++;

                    if (parent[node] == -1 && childrenCount > 0 || 
                        parent[node] != -1 && lowpoint[child] >= depth[node])
                    {
                        HashSet<int> component = new HashSet<int>();

                        while (true)
                        {
                            int stackChild = stack.Pop();
                            int stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackChild == child &&
                                stackNode == node)
                            {
                                break;
                            }
                        }

                        components.Add(component);
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child &&
                    depth[child] < lowpoint[node])
                {
                    lowpoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }
    }
}