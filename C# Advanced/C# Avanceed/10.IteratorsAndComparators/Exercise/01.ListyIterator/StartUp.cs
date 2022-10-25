using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ListyIterator
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

                cmd = Console.ReadLine();
            }
        }
    }
}
