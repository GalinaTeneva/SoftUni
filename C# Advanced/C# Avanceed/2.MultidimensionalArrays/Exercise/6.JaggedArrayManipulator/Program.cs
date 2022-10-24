using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] rowElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();

                jaggedArray[row] = rowElements;
            }

            ModifyJaggedArray(jaggedArray);

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] cmdInfo = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmdInfo[1]);
                int col = int.Parse(cmdInfo[2]);

                bool areValidIndexes = row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;

                if (areValidIndexes)
                {
                    string cmdType = cmdInfo[0];
                    int value = int.Parse(cmdInfo[3]);
                    switch (cmdType)
                    {
                        case "Add":
                            jaggedArray[row][col] += value; 
                            break;
                        case "Subtract":
                            jaggedArray[row][col] -= value; 
                            break;
                    }
                }

                cmd = Console.ReadLine();
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[row]));
            }
        }

        private static void ModifyJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
        }
    }
}
