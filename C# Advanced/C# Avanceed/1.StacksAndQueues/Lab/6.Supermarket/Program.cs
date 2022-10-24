using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string currInput = Console.ReadLine();

            Queue<string> customers = new Queue<string>();

            while (currInput != "End")
            {
                if (currInput == "Paid")
                {
                    foreach (string customer in customers)
                    {
                        Console.WriteLine(customer);
                    }

                    customers.Clear();
                    currInput = Console.ReadLine();

                    continue;
                }

                customers.Enqueue(currInput);

                currInput = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
