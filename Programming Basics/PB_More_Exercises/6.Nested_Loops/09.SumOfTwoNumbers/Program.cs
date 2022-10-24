using System;

namespace _09.SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            bool isTrereMagicNum = false;
            int combinationsCounter = 0;
            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    combinationsCounter++;
                    int currSum = i + j;
                    if (currSum == magicNum)
                    {
                        isTrereMagicNum = true;
                        Console.WriteLine($"Combination N:{combinationsCounter} ({i} + {j} = {magicNum})");
                        break;
                    }
                }

                if (isTrereMagicNum)
                {
                    break;
                }
            }

            if (!isTrereMagicNum)
            {
                Console.WriteLine($"{combinationsCounter} combinations - neither equals {magicNum}");
            }
        }
    }
}
