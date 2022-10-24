using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
            double powerNum = double.Parse(Console.ReadLine());

            Console.WriteLine(MathPower(baseNum, powerNum));
        }

        static double MathPower(double @base, double power)
        {
            double result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= @base;
            }

            return result;
        }
    }
}
