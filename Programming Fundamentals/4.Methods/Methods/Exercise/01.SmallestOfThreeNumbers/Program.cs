using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            PrintSmallestOfThree(firstNum, secondNum, thirdNum);
        }

        static void PrintSmallestOfThree(int firstNum, int secondNum, int thirdNum)
        {
            int smallestNum = int.MaxValue;
            if (firstNum < smallestNum)
            {
                smallestNum = firstNum;
            }
            if (secondNum < smallestNum)
            {
                smallestNum = secondNum;
            }
            if (thirdNum < smallestNum)
            {
                smallestNum = thirdNum;
            }
            Console.WriteLine(smallestNum);
        }
    }
}
