using System;

namespace _07.NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            PrintNxNMatrix(num);
        }

        private static void PrintNxNMatrix(int num)
        {
            for (int currentLine = 1; currentLine <= num; currentLine++)
            {
                for (int currentDigit = 1; currentDigit <= num; currentDigit++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
