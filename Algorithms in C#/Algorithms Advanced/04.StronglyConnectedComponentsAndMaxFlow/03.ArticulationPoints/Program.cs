namespace _03.ArticulationPoints
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depth;
        private static int[] lowpoint;
        private static int[] parent;
        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            visited = new bool[nodes];
            depth = new int[nodes];
            lowpoint = new int[nodes];
            parent = new int[nodes];

            for (int n = 0; n < graph.Length; n++)
            {
                graph[n] = new List<int>();
                parent[n] = -1;
            }

            for (int n = 0; n < nodes; n++)
            {
                int[] line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                int node = line[0];

                for (int j = 1; j < line.Length; j++)
                {
                    int child = line[j];

                    graph[node].Add(child);
                    graph[child].Add(node);
                }
            }

            articulationPoints = new List<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                FindArticulationPoint(node, 1);
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void FindArticulationPoint(int node, int currDepth)
        {
            visited[node] = true;
            depth[node] = currDepth;
            lowpoint[node] = currDepth;

            int childCount = 0;
            bool isArticulationPoint = false;

            foreach (int child in graph[node])
            {
                if (!visited[child])
                {
                    parent[child] = node;

                    FindArticulationPoint(child, currDepth + 1);

                    childCount++;

                    if (lowpoint[child] >= depth[node])
                    {
                        isArticulationPoint = true;
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child)
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
                }
            }

            if ((parent[node] == -1 && childCount > 1) ||
                (parent[node] != -1 && isArticulationPoint))
            {
                articulationPoints.Add(node);
            }
        }
    }
}