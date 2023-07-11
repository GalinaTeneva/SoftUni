namespace _03.ContaminatedPath
{
    internal class Program
    {
        private static char[,] matrix;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            matrix = GenerateGrid(size);

            string[] contamonatedSells = Console.ReadLine().Split();

            foreach (var currCell in contamonatedSells)
            {
                int[] CurrCellData = currCell.Split(",").Select(int.Parse).ToArray();

                int row = currCell[0];
                int col = currCell[1];

                matrix[row, col] = '*';
            }
        }

        private static char[,] GenerateGrid(int size)
        {
            for (int r = 0; r < size; r++)
            {
                string[] currLine = Console.ReadLine().Split();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = char.Parse(currLine[c]);
                }
            }

            return matrix;
        }
    }
}