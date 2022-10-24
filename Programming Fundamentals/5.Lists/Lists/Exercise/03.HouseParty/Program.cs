using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int currentCommand = 1; currentCommand <= numberOfCommands; currentCommand++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string personToAddOrDelete = input[0];

                if (input.Contains("not"))
                {
                    if (guestList.Contains(personToAddOrDelete))
                    {
                        guestList.Remove(personToAddOrDelete);
                    }
                    else
                    {
                        Console.WriteLine($"{personToAddOrDelete} is not in the list!");
                    }
                }
                else
                {
                    if (guestList.Contains(personToAddOrDelete))
                    {
                        Console.WriteLine($"{personToAddOrDelete} is already in the list!");
                    }
                    else
                    {
                        guestList.Add(personToAddOrDelete);
                    }
                }
            }

            foreach (string guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
