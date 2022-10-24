using System;

namespace _13.PrimePairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstPairNumsStart = int.Parse(Console.ReadLine());
            int secondPairNumsStart = int.Parse(Console.ReadLine());
            int firstPairNumsDiffToEnd = int.Parse(Console.ReadLine());
            int secondPairNumsDiffToEnd = int.Parse(Console.ReadLine());

            for (int i = firstPairNumsStart; i <= firstPairNumsStart + firstPairNumsDiffToEnd; i++)
            {
                for (int j = secondPairNumsStart; j <= secondPairNumsStart + secondPairNumsDiffToEnd; j++)
                {
                    bool isFirstPairPrime = true;
                    bool isSecondPairPrime = true;

                    for (int k = 2; k <= Math.Sqrt(i); k++)
                    {
                        if (i % k == 0)
                        {
                            isFirstPairPrime = false;
                            break;
                        }
                    }

                    for (int k = 2; k <= Math.Sqrt(j); k++)
                    {
                        if (j % k == 0)
                        {
                            isFirstPairPrime = false;
                            break;
                        }
                    }

                    if (isFirstPairPrime && isSecondPairPrime)
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }
    }
}
