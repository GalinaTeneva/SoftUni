namespace _02.MoveDownRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                int[] elements = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = elements[c];
                }
            }

            int[,] newMatrix = new int[rows, cols];

            newMatrix[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                newMatrix[0, c] = newMatrix[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                newMatrix[r, 0] = newMatrix[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    int upper = newMatrix[r - 1, c];
                    int left = newMatrix[r, c - 1];

                    newMatrix[r, c] = Math.Max(upper, left) + matrix[r, c];
                }
            }

            Stack<string> path = new Stack<string>();

            int row = rows - 1;
            int col = cols - 1;

            while (row > 0 && col > 0)
            {
                path.Push($"[{row}, {col}]");

                int upper = newMatrix[row - 1, col];
                int left = newMatrix[row, col - 1];

                if (upper > left)
                {
                    row -= 1;
                }
                else
                {
                    col -= 1;
                }
            }

            while (row > 0)
            {
                path.Push($"[{row}, {col}]");

                row -= 1;
            }

            while (col > 0)
            {
                path.Push($"[{row}, {col}]");

                col -= 1;
            }

            path.Push($"[{row}, {col}]");

            Console.WriteLine(string.Join(" ", path));
        }
    }
}