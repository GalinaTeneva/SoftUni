using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixParam = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int matrixRowsCount = matrixParam[0];
            int matrixColsCount = matrixParam[1];

            int[,] matrix = new int[matrixRowsCount, matrixColsCount];

            int sum = 0;

            for (int currRow = 0; currRow < matrixRowsCount; currRow++)
            {
                int[] currData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int currCol = 0; currCol < matrixColsCount; currCol++)
                {
                    matrix[currRow, currCol] = currData[currCol];
                    sum += currData[currCol];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
