using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sumValue = SumOfTwoNums(firstNum, secondNum);
            int subtractedValue = Subtraction(sumValue, thirdNum);

            Console.WriteLine(subtractedValue);
        }
        static int SumOfTwoNums(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        static int Subtraction(int firstNum, int secondNum)
        {
            return firstNum - secondNum;
        }

    }
}
