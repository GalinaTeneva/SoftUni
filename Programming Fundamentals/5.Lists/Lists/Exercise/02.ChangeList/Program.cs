using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "end")
                {
                    break;
                }
                else if (command[0] == "Delete")
                {
                    int elementToDelete = int.Parse(command[1]);
                    numbers.RemoveAll(element => element == elementToDelete);
                }
                else if (command[0] == "Insert")
                {
                    int elementToInsert = int.Parse(command[1]);
                    int indexToInsert = int.Parse(command[2]);
                    numbers.Insert(indexToInsert, elementToInsert);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
