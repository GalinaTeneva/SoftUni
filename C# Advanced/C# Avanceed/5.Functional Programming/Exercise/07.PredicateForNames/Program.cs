using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[], Predicate<string>> print = (names, match) =>
            {
                for (int i = 0; i < names.Length; i++)
                {
                    if (match(names[i]))
                    {
                        Console.WriteLine(names[i]);
                    }
                }
            };

            int requiredLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(names, n => n.Length <= requiredLength);
        }
    }
}
