using System;

namespace _3.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int innerFigureRows = 3;
            int innerFigureCols = 3;

            string[] matrixSize = Console.ReadLine().Split();

            int[,] matrix = new int[int.Parse(matrixSize[0]), int.Parse(matrixSize[1])];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(rowData[col]);
                }
            }

            int maxSum = int.MinValue;
            int maxSumSartRow = 0;
            int maxSumStartCol = 0;
            for (int row = 0; row < matrix.GetLength(0) -  innerFigureRows + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - innerFigureCols + 1; col++)
                {
                    int currSum = 0;
                    for (int innRow = 0; innRow < innerFigureRows; innRow++)
                    {
                        for (int innCol = 0; innCol < innerFigureCols; innCol++)
                        {
                            currSum += matrix[row + innRow, col + innCol];
                        }
                    }

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxSumSartRow = row;
                        maxSumStartCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < innerFigureRows; row++)
            {
                for (int col = 0; col < innerFigureCols; col++)
                {
                    Console.Write(matrix[maxSumSartRow + row, maxSumStartCol + col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
