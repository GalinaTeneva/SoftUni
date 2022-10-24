using System;

namespace _10.LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            bool isUpper = Char.IsUpper(input);

            Console.WriteLine(isUpper ? "upper-case": "lower-case");
        }
    }
}
