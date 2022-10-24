using System;

namespace _10._Odd_Even_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberCount = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i < numberCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    sum1 += number;
                }
                if (i % 2 != 0)
                {
                    sum2 += number;
                }
            }

            int diff = Math.Abs(sum1 - sum2);
            if (diff == 0)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("Sum = " + sum1);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("Diff = " + diff);
            }
        }
    }
}
