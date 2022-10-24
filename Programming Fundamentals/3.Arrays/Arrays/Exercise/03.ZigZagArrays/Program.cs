using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalInputs = int.Parse(Console.ReadLine());
            int[] firstNewArr = new int[totalInputs];
            int[] secondNewArr = new int[totalInputs];

            for (int currentLine = 0; currentLine < totalInputs; currentLine++)
            {
                int[] currentLineNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (currentLine % 2 == 0 )
                {
                    firstNewArr[currentLine] = currentLineNums[0];
                    secondNewArr[currentLine] = currentLineNums[1];
                }
                else
                {
                    firstNewArr[currentLine] = currentLineNums[1];
                    secondNewArr[currentLine] = currentLineNums[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstNewArr));
            Console.WriteLine(string.Join(" ", secondNewArr));
        }
    }
}
