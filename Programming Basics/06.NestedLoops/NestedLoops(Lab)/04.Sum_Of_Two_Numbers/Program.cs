using System;

namespace _04.Sum_Of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int combinationsCounter = 0;

            for (int i = num1; i <= num2; i++)
            {
                for (int j = num1; j <= num2; j++)
                {
                    combinationsCounter++;

                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{combinationsCounter} ({i} + {j} = {magicNum})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinationsCounter} combinations - neither equals {magicNum}");
        }
    }
}
