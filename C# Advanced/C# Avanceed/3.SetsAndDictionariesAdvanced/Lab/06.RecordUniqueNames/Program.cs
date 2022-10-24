using System;
using System.Collections.Generic;

namespace _06.RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
