using System;

namespace _10._Multiply_By_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double num = double.Parse(Console.ReadLine());
                if (num < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                }

                double result = num * 2;
                Console.WriteLine($"Result: {result:F2}");
            }
        }
    }
}
