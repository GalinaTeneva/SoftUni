using System;

namespace _09.Sum_Of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalOddNums = int.Parse(Console.ReadLine());

            int sumOfOddNums = 0;
            int counter = 0;
            for (int currentNum = 1; currentNum <= int.MaxValue; currentNum += 2)
            {
                counter++;
                Console.WriteLine(currentNum);
                sumOfOddNums += currentNum;

                if (counter == totalOddNums)
                {
                    break;
                }
            }

            Console.WriteLine("Sum: {0}", sumOfOddNums);
        }
    }
}
