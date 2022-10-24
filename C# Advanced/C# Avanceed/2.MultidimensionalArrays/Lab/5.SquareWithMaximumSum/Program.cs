using System;
using System.Linq;

namespace _5.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for(int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int bestSum = int.MinValue;
            int bestSumStartRow = 0;
            int bestSumStartCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > bestSum)
                    {
                        bestSum = currSum;
                        bestSumStartRow = row;
                        bestSumStartCol = col;
                    }
                }
            }

            for (int row = bestSumStartRow; row < bestSumStartRow + 2; row++)
            {
                for (int col = bestSumStartCol; col < bestSumStartCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(bestSum);
        }
    }
}
