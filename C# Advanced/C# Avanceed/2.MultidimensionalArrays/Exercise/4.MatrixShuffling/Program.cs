using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrixSize[0]; row++)
            {
                string[] rowData = Console.ReadLine().Split();
                for (int col = 0; col < matrixSize[1]; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            string[] cmd = Console.ReadLine().Split();
            bool isInputValid = true;
            while (cmd[0] != "END")
            {
                if (cmd[0] == "swap" && cmd.Length == 5)
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);

                    bool areValidIndexes = row1 >= 0 && row1 < matrix.GetLength(0) &&
                                    col1 >= 0 && col1 < matrix.GetLength(1) &&
                                    row2 >= 0 && row2 < matrix.GetLength(0) &&
                                    col2 >= 0 && col2 < matrix.GetLength(1);

                    if (areValidIndexes)
                    {
                        isInputValid = true;
                        string firstStr = matrix[row1, col1];
                        string secondtStr = matrix[row2, col2];
                        matrix[row1, col1] = secondtStr;
                        matrix[row2, col2] = firstStr;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        isInputValid = false;
                    }
                }
                else
                {
                    isInputValid = false;
                }

                if (!isInputValid)
                {
                    Console.WriteLine("Invalid input!");
                }

                cmd = Console.ReadLine().Split();
            }
        }
    }
}
