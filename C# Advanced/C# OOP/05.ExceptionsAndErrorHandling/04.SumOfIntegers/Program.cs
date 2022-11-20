using System;
using System.Numerics;

namespace SumOfIntegers
{
    class Program
    {
        static void Main()
        {
            
            string[] input = Console.ReadLine().Split(" ");

            BigInteger integerSum = 0;

            foreach (string item in input)
            {
                try
                {
                    long num = ItemAsInteger(item);
                    integerSum += num;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }

                Console.WriteLine($"Element '{item}' processed - current sum: {integerSum}");
            }

            Console.WriteLine($"The total sum of all integers is: {integerSum}");
        }

        static long ItemAsInteger(string input)
        {
            long num = 0;
            if (!Int64.TryParse(input, out num))
            {
                throw new FormatException($"The element '{input}' is in wrong format!");
            }

            if (num > int.MaxValue || num < int.MinValue)
            {
                throw new OverflowException($"The element '{input}' is out of range!");
            }
            
            return num;
        }
    }
}

