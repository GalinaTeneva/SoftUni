using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            string cmd = Console.ReadLine();
            while (true)
            {
                if (cmd == "Move")
                {
                    Console.WriteLine(listyIterator.Move());
                }
                else if (cmd == "HasNext")
                {
                    Console.WriteLine(listyIterator.HasNext());
                }
                else if (cmd == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception exception)
                    {

                        Console.WriteLine(exception.Message);
                    }
                }
                else if (cmd == "PrintAll")
                {
                    foreach (var item in listyIterator)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
