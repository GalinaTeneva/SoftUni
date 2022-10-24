using System;

namespace _2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] matrixSize = Console.ReadLine().Split();

            char[,] matrix = new char[int.Parse(matrixSize[0]), int.Parse(matrixSize[1])];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] symbols = Console.ReadLine().Split();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = char.Parse(symbols[col]);
                }
            }

            int squaresFound = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col+1] && matrix[row, col] == matrix[row+1, col] && matrix[row, col] == matrix[row+1,col+1])
                    {
                        squaresFound++;
                    }
                }
            }

            Console.WriteLine(squaresFound);
        }
    }
}
