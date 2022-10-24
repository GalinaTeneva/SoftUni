using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowData = Console.ReadLine().Split().Select(n => int.Parse(n)).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primarySum += matrix[i, i];
                secondarySum += matrix[i, matrix.GetLength(1) - 1 - i];
            }

            Console.WriteLine($"{Math.Abs(primarySum - secondarySum)}");
        }
    }
}
