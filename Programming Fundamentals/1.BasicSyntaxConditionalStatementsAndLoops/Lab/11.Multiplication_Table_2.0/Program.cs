using System;

namespace _11.Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int theInteger = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            do
            {
                int product = theInteger * multiplier;
                Console.WriteLine($"{theInteger} X {multiplier} = {product}");
                multiplier++;
            } while (multiplier <= 10);
        }
    }
}
