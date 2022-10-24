using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> nums = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int elementsToPop = inputTokens[1];
            int elementToFind = inputTokens[2];

            for (int i = 1; i <= elementsToPop; i++)
            {
                nums.Pop();

                if (nums.Count == 0)
                {
                    Console.WriteLine("0");
                    return;
                }
            }

            if (nums.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestNum = int.MaxValue;

                while (nums.Count > 0)
                {
                    int currNum = nums.Pop();
                    if (currNum <= smallestNum)
                    {
                        smallestNum = currNum;
                    }
                }

                Console.WriteLine(smallestNum);
            }
        }
    }
}
