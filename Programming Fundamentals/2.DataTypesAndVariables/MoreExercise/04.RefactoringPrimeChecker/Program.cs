using System;

namespace _04.RefactoringPrimeChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            int LastNum = int.Parse(Console.ReadLine());

            for (int currNum = 2; currNum <= LastNum; currNum++)
            {
                bool isPrime = true;

                for (int i = 2; i < currNum; i++)
                {
                    if (currNum % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine($"{currNum} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
