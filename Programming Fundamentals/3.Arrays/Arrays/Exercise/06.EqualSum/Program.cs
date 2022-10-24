using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool isEqual = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                int leftSum = 0;
                for (int j = i; j > 0; j--)
                {

                    int nextLeftElementPosition = j - 1;

                    if (j > 0)
                    {
                        leftSum += numbers[nextLeftElementPosition];
                    }
                }

                int rightSum = 0;
                for (int k = i; k < numbers.Length; k++)
                {
                    int nextLeftElementPosition = k + 1;

                    if (k < numbers.Length - 1)
                    {
                        rightSum += numbers[nextLeftElementPosition];
                    }
                }

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    isEqual = true;
                }
            }
            if (!isEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
