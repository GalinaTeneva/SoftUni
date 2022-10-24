using System;

namespace _02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[], string> addTitle = (names, title) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            addTitle(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries), "Sir");
        }
    }
}
