using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> nums = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
           
            int elementsToPop = inputTokens[1];
            int elementToFind = inputTokens[2];

            for (int i = 1; i <= elementsToPop; i++)
            {
                nums.Dequeue();

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
                Console.WriteLine(nums.Min());
            }
        }
    }
}
