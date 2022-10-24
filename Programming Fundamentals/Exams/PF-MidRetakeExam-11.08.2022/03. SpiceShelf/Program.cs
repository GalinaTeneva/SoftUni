using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._SpiceShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> spices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "done")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandTokens[0];

                if (commandType == "AddSpice")
                {
                    string spice = commandTokens[1];
                    if (!spices.Contains(spice))
                    {
                        spices.Add(spice);
                    }
                }
                else if (commandType == "AddManySpices")
                {
                    int index = int.Parse(commandTokens[1]);
                    string[] spicesToAdd = commandTokens[2].Split('|', StringSplitOptions.RemoveEmptyEntries);

                    spices.InsertRange(index, spicesToAdd);
                }
                else if (commandType == "SwapSpices")
                {
                    string firstSpice = commandTokens[1];
                    string secondSpice = commandTokens[2];
                    if (spices.Contains(firstSpice) && spices.Contains(secondSpice))
                    {
                        int indexOfFirstSpice = spices.IndexOf(firstSpice);
                        int indexOfSecondSpice = spices.IndexOf(secondSpice);
                        spices.Remove(firstSpice);
                        spices.Remove(secondSpice);
                        spices.Insert(indexOfFirstSpice, secondSpice);
                        spices.Insert(indexOfSecondSpice, firstSpice);
                    }
                }
                else if (commandType == "ThrowAwaySpices")
                {
                    string spice = commandTokens[1];
                    int number = int.Parse(commandTokens[2]);

                    if (spices.Contains(spice))
                    {
                        int index = spices.IndexOf(spice);
                        spices.RemoveRange(index, number);
                    }
                }
                else if (commandType == "Arrange")
                {
                    spices.Sort();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(' ', spices));
        }
    }
}
