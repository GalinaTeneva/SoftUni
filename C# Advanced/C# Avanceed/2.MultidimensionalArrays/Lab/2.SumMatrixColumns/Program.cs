using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixParam = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rowsCount = matrixParam[0];
            int colsCount = matrixParam[1];

            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }

        }
    }
}
