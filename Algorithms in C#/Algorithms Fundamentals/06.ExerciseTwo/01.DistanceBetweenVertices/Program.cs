namespace _01.DistanceBetweenVertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                string[] currNodeInfo = Console.ReadLine()
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                int currNode = int.Parse(currNodeInfo[0]);

                if (currNodeInfo.Length == 1)
                {
                    graph[currNode] = new List<int>();
                }
                else
                {
                    List<int> children = currNodeInfo[1]
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[currNode] = children;
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                int[] currPairInfo = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                int start = currPairInfo[0];
                int end = currPairInfo[1];

                int steps = BFS(start, end);

                Console.WriteLine($"{{{start}, {end}}} -> {steps}");
            }
        }

        private static int BFS(int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            HashSet<int> visited = new HashSet<int> { start };
            Dictionary<int, int> parent = new Dictionary<int, int> { { start, -1} };

            while (queue.Count > 0)
            {
                int currNode = queue.Dequeue();

                if (currNode == end)
                {
                    return GetSteps(parent, end);
                }

                foreach (int child in graph[currNode])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                    parent[child] = currNode;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int end)
        {
            int steps = 0;

            int node = end;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}