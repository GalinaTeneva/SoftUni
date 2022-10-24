using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNum = int.MinValue;
            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                int currentNum = int.Parse(input);

                if (currentNum > maxNum)
                {
                    maxNum = currentNum;
                }
            }

            Console.WriteLine(maxNum);
        }
    }
}
