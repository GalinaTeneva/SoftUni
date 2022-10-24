using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> treasureChest = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = Console.ReadLine();

            while (command != "Yohoho!")
            {
                string[] commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commandTokens[0] == "Loot")
                {
                    for (int i = 1; i < commandTokens.Length; i++)
                    {
                        if (!treasureChest.Contains(commandTokens[i]))
                        {
                            treasureChest.Insert(0, commandTokens[i]);
                        }
                    }
                }
                else if (commandTokens[0] == "Drop")
                {
                    int index = int.Parse(commandTokens[1]);
                    if (index >= 0 && index < treasureChest.Count)
                    {
                        string loot = treasureChest.ElementAt(index);
                        treasureChest.RemoveAt(index);
                        treasureChest.Add(loot);
                    }
                }
                else if (commandTokens[0] == "Steal")
                {
                    int count = int.Parse(commandTokens[1]);

                    if (treasureChest.Count <= count)
                    {
                        Console.WriteLine(string.Join(", ", treasureChest));
                        treasureChest.Clear();
                    }
                    else
                    {
                        var stolenItems = treasureChest.TakeLast(count).ToList();
                        treasureChest.RemoveRange(treasureChest.Count - count, count);
                        Console.WriteLine(string.Join(", ", stolenItems));
                    }
                }

                command = Console.ReadLine();
            }

            if (treasureChest.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                double treasureItemsLengthSum = 0;
                foreach (var item in treasureChest)
                {
                    treasureItemsLengthSum += item.Length;
                }

                double averageGain = treasureItemsLengthSum / treasureChest.Count;

                Console.WriteLine($"Average treasure gain: {averageGain:F2} pirate credits.");
            }
        }
    }
}
