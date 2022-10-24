using System;

namespace _09._Left_And_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());

            int sum1 = 0;
            for (int i = 0; i < numCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum1 += num;
            }

            int sum2 = 0;
            for (int i = 0; i < numCount; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum2 += num;
            }

            int diff = sum1 - sum2;
            if (diff == 0)
            {
                Console.WriteLine("Yes, sum = " + sum1);
            }
            else
            {
                Console.WriteLine("No, diff = " + Math.Abs(diff));
            }
        }
    }
}
