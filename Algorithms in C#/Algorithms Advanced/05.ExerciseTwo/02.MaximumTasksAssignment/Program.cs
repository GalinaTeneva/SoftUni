using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MaximumTasksAssignment
{
    internal class Program
    {
        private static bool[,] graph;
        private static int[] parent;

        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int tasks = int.Parse(Console.ReadLine());

            int nodes = people + tasks + 2;

            graph = new bool[nodes, nodes];

            for (int p = 1; p <= people; p++)
            {
                graph[0, p] = true;
            }

            for (int t = people + 1; t <= people + tasks; t++)
            {
                graph[t, nodes - 1] = true;
            }

            for (int person = 1; person <= people; person++)
            {
                string pesronTasks = Console.ReadLine();

                for (int task = 0; task < pesronTasks.Length; task++)
                {
                    if (pesronTasks[task] == 'Y')
                    {
                        graph[person, people + task + 1] = true;
                    }
                }
            }

            int source = 0;
            int target = nodes - 1;

            parent = new int[nodes];
            Array.Fill(parent, -1);

            while (BFS(source, target))
            {
                int node = target;

                while (parent[node] != -1)
                {
                    int prev = parent[node];

                    graph[prev, node] = false;
                    graph[node, prev] = true;

                    node = prev;
                }
            }

            for (int task = people + 1; task <= people + tasks; task++)
            {
                for (int idx = 0; idx < graph.GetLength(1); idx++)
                {
                    if (graph[task, idx])
                    {
                        Console.WriteLine($"{(Char)(64 + idx)}-{task - people}");
                    }
                }
            }
        }

        private static bool BFS(int source, int target)
        {
            bool[] visited = new bool[graph.GetLength(0)];
            Queue<int> queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (!visited[child] && graph[node, child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return visited[target];
        }
    }
}