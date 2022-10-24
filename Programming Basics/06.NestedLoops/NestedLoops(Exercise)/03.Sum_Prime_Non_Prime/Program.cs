using System;

namespace _03.Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            int primeNumSum = 0;
            int nonPrimeNumSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "stop")
                {
                    Console.WriteLine($"Sum of all prime numbers is: {primeNumSum}");
                    Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumSum}");
                    return;
                }

                int currentNum = int.Parse(input);

                if (currentNum < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool isPrime = true;
                for (int i = 2; i < currentNum; i++)    // for (int i = 2; i <= Math.Sqrt(currentNum); i++)
                {
                    if (currentNum % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeNumSum += currentNum;
                }
                else
                {
                    nonPrimeNumSum += currentNum;
                }
            }
        }
    }
}
