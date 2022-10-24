using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] command = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string item = command[1];
                if (command[0] == "Collect")
                {
                    if (!Exist(item, items))
                    {
                        items.Add(item);
                    }
                }
                else if (command[0] == "Drop")
                {
                    if (Exist(item, items))
                    {
                        items.Remove(item);
                    }
                }
                else if (command[0] == "Combine Items")
                {
                    string[] itemsData = item.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = itemsData[0];
                    string newItem = itemsData[1];

                    if (Exist(oldItem, items))
                    {
                        int firstItemIndex = items.FindIndex(i => i == oldItem);
                        items.Insert(firstItemIndex + 1, newItem);
                    }
                }
                else if (command[0] == "Renew")
                {
                    if (Exist(item, items))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", items));
        }

        private static bool Exist(string item, List<string> items)
        {
            if (items.Contains(item))
            {
                return true;
            }

            return false;
        }
    }
}
