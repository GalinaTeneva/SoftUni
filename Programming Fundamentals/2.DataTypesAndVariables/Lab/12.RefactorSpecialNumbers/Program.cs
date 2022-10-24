using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            bool isSpecialNum = false;
            for (int i = 1; i <= inputNum; i++)
            {
                int currentNum = i;
                int sum = 0;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum = currentNum / 10;
                }
                isSpecialNum = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", i, isSpecialNum);
                //i = currentNum;
            }

        }
    }
}
