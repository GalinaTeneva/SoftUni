using System;

namespace _11._Odd_Even_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalNums = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double evenSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= totalNums; i++)
            {
                double currentNum = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += currentNum;

                    if (currentNum < evenMin)
                    {
                        evenMin = currentNum;
                    }
                    if (currentNum > evenMax)
                    {
                        evenMax = currentNum;
                    }
                }
                else
                {
                    oddSum += currentNum;

                    if (currentNum < oddMin)
                    {
                        oddMin = currentNum;
                    }
                    if (currentNum > oddMax)
                    {
                        oddMax = currentNum;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:F2},");

            if (oddMin == double.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }
            else
            {
                Console.WriteLine($"OddMin={oddMin:F2},");
            }

            if (oddMax == double.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }
            else
            {
                Console.WriteLine($"OddMax={oddMax:F2},");
            }

            Console.WriteLine($"EvenSum={evenSum:F2},");

            if (evenMin == double.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }
            else
            {
                Console.WriteLine($"EvenMin={evenMin:F2},");
            }

            if (evenMax == double.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }
            else
            {
                Console.WriteLine($"EvenMax={evenMax:F2}");
            }
        }
    }
}
