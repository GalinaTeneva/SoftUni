using System;

namespace _10.Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int currentLine = 1; currentLine <= 10; currentLine++)
            {
                int product = num * currentLine;
                Console.WriteLine($"{num} X {currentLine} = {product}");
            }
        }
    }
}
