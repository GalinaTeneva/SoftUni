using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!", StringSplitOptions.RemoveEmptyEntries).ToList();
            string currentCommand = Console.ReadLine();

            while (currentCommand != "Go Shopping!")
            {
                string[] commandTokens = currentCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentItem = commandTokens[1];


                if (commandTokens[0] == "Urgent")
                {
                    if (!shoppingList.Contains(currentItem))
                    {
                        shoppingList.Insert(0, currentItem);
                    }
                }
                else if (commandTokens[0] == "Unnecessary")
                {
                    if (shoppingList.Contains(currentItem))
                    {
                        shoppingList.Remove(currentItem);
                    }
                }
                else if (commandTokens[0] == "Correct")
                {
                    if (shoppingList.Contains(currentItem))
                    {
                        int currentItemIndex = shoppingList.IndexOf(currentItem);
                        string newItem = commandTokens[2];
                        shoppingList[currentItemIndex] = newItem;
                    }
                }
                else if (commandTokens[0] == "Rearrange")
                {
                    if (shoppingList.Contains(currentItem))
                    {
                        shoppingList.Remove(currentItem);
                        shoppingList.Add(currentItem);
                    }
                }

                currentCommand = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
