using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] itemsInfo = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = itemsInfo[0];

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe.Add(colour, new Dictionary<string, int>());
                }

                string[] clothes = itemsInfo[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in clothes)
                {
                    if (!wardrobe[colour].ContainsKey(item))
                    {
                        wardrobe[colour].Add(item, 0);
                    }

                    wardrobe[colour][item]++;
                }
            }

            string[] searchItemInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string searchItemColour = searchItemInfo[0];
            string searchItemType = searchItemInfo[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var pair in kvp.Value)
                {
                    if (kvp.Key == searchItemColour && pair.Key == searchItemType)
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }
                }
            }
        }
    }
}
