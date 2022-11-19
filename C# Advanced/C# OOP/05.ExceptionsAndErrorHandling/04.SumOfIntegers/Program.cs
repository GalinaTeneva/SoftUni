using System;

namespace SumOfIntegers
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int integerSum = 0;

            foreach (string item in input)
            {
                try
                {
                    int num = ItemAsInteger(item);
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

        static int ItemAsInteger(string input)
        {
            long longNum = 0;
            int num = 0;

            if (Int64.TryParse(input, out longNum))
            {
                if (longNum > int.MaxValue || longNum < int.MinValue)
                {
                    throw new OverflowException($"The element '{input}' is out of range!");
                }
                if (!int.TryParse(input, out num))
                {
                    throw new FormatException($"The element '{input}' is in wrong format!");
                }
            }

            return num;
        }
    }
}

