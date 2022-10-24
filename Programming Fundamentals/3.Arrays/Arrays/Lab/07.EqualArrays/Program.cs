using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

            bool areIdentical = true;
            int sum = 0;
            for (int i = 0; i < firstInput.Length; i++)
            {
                if (firstInput[i] != secondInput[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    areIdentical = false;
                    break;
                }
                else
                {
                    sum += firstInput[i];
                }
            }
            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }


            ////Convetring string array to int array - second way;

            //string[] firstInput = Console.ReadLine().Split();
            //string[] secondInput = Console.ReadLine().Split();

            //int[] firstIntArr = new int[firstInput.Length];
            //int[] secondIntArr = new int[secondInput.Length];

            //for (int i = 0; i < firstIntArr.Length; i++)
            //{
            //    firstIntArr[i] = int.Parse(firstInput[i]);
            //    secondIntArr[i] = int.Parse(secondInput[i]);
            //}

            //bool areIdentical = true;
            //int sum = 0;
            //for (int i = 0; i < firstInput.Length; i++)
            //{
            //    if (firstInput[i] != secondInput[i])
            //    {
            //        Console.WriteLine($"Arrays are not identical. Found difference at {i} index.");
            //        areIdentical = false;
            //        break;
            //    }
            //    else
            //    {
            //        sum += firstIntArr[i];
            //    }
            //}
            //if (areIdentical)
            //{
            //    Console.WriteLine($"Arrays are identical. Sum: {sum}");
            //}
        }
    }
}
