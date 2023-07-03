using System.ComponentModel.Design;

namespace _02.AreasInMatrix
{
    internal class Program
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static Dictionary<char, int> areas;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            matrix = new char[rows, cols];
            visited = new bool[rows, cols];
            areas = new Dictionary<char, int>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string currLine = Console.ReadLine();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = currLine[c];
                }
            }

            int areasCount = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (!visited[r, c])
                    {
                        char nodeValue = matrix[r, c];
                        DFS(r, c, nodeValue);

                        areasCount++;

                        if (!areas.ContainsKey(nodeValue))
                        {
                            areas.Add(nodeValue, 0);
                        }

                        areas[nodeValue]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areasCount}");

            foreach (var kvp in areas.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }
        }

        private static void DFS(int row, int col, char parentNode)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (matrix[row, col] != parentNode)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col - 1, parentNode);
            DFS(row, col + 1, parentNode);
            DFS(row - 1, col, parentNode);
            DFS(row + 1, col, parentNode);
        }
    }
}