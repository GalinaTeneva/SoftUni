using System;

namespace _02.Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());

            int sum = 0;
            int maxNum = int.MinValue;

            for (int i = 0; i < numCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;

                if (number > maxNum)
                {
                    maxNum = number;
                }
            }

            int sumWithoutMaxNum = sum - maxNum;
            int diff = Math.Abs(maxNum - sumWithoutMaxNum);
            if (maxNum == sumWithoutMaxNum)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + sumWithoutMaxNum);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
