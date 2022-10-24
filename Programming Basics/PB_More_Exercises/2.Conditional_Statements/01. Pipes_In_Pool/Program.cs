using System;

namespace _01._Pipes_In_Pool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine());
            int firstPipeFlow = int.Parse(Console.ReadLine());
            int secondPipeFlow = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double litersFromFirstPipe = firstPipeFlow * hours;
            double litersFromSecondPipe = secondPipeFlow * hours;
            double totalLiters = litersFromFirstPipe + litersFromSecondPipe;

            if (volume >= totalLiters)
            {
                double totalLitersPercent = totalLiters / volume * 100;
                double litersFromFirstPipePercent = litersFromFirstPipe / totalLiters * 100;
                double litersFromSecondPipePercent = litersFromSecondPipe / totalLiters * 100;

                Console.WriteLine($"The pool is {totalLitersPercent:F2}% full. Pipe 1: {litersFromFirstPipePercent:F2}%. Pipe 2: {litersFromSecondPipePercent:F2}%.");
            }
            else
            {
                double overflow = totalLiters - volume;
                Console.WriteLine($"For {hours:F2} hours the pool overflows with {overflow:F2} liters.");
            }

        }
    }
}
