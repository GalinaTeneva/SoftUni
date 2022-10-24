using System;

namespace _04.Print_And_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());

            int sum = 0;
            for (int currentNum = startingNum; currentNum <= endingNum; currentNum++)
            {
                Console.Write(currentNum + " ");
                sum += currentNum;
            }

            Console.WriteLine();
            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
