using System;

namespace _04.PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                PrintLine(1, i);
            }

            for (int i = input - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }

        static void PrintLine(int startNum, int endNum)
        {
            for (int currentDigit = startNum; currentDigit <= endNum; currentDigit++)
            {
                Console.Write(currentDigit + " ");
            }

            Console.WriteLine();
        }
    }
}
