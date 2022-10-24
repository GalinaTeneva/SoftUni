using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotationsNum = int.Parse(Console.ReadLine());

            for (int currentRotation = 1; currentRotation <= rotationsNum; currentRotation++)
            {
                int[] newArrayOfNumbers = new int[numbers.Length];
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i != numbers.Length - 1)
                    {
                        newArrayOfNumbers[i] = numbers[i + 1];
                    }
                    else
                    {
                        newArrayOfNumbers[i] = numbers[0];
                    }
                }
                numbers = newArrayOfNumbers;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
