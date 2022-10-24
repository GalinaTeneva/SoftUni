using System;
using System.Linq;

namespace _11.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checker = (name, number) => name.Sum(ch => ch) >= number;

            Func<string[], int, Func<string, int, bool>, string> getName = (names, number, checker) =>
               names.FirstOrDefault(name => checker(name, number));

            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(getName(names, number, checker));
        }
    }
}
