using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();

            int currNum = 1;
            int endNum = 100;
            while (numbers.Count != 10)
            {
                try
                {
                    currNum = ReadNumber(currNum, endNum);
                    numbers.Add(currNum);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            int num;
            if (!int.TryParse(input, out num))
            {
                throw new ArgumentException("Invalid Number!");
            }
            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - 100!");
            }

            return num;
        }
    }
}
