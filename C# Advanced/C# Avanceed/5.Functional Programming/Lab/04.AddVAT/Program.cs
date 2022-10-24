using System;
using System.Linq;

namespace _04.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, string> addVAT = x => (x * 1.2).ToString("F2");

            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(addVAT)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, prices));
        }
    }
}
