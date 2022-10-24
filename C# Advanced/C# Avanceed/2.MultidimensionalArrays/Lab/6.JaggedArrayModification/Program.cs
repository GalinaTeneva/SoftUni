using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] command = Console.ReadLine().Split();
            while (command[0] != "END")
            {
                int cmdRow = int.Parse(command[1]);
                int cmdCol = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                bool validCoordinates = cmdRow >= 0 && cmdRow < jaggedArr.Length && cmdCol >= 0 && cmdCol < jaggedArr[cmdRow].Length;
                if (!validCoordinates)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        jaggedArr[cmdRow][cmdCol] += value;
                    }
                    else if (command[0] == "Subtract")
                    {
                        jaggedArr[cmdRow][cmdCol] -= value;
                    }
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < jaggedArr.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }
        }
    }
}
