using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string currResource = Console.ReadLine();
            while (currResource != "stop")
            {
                int currQuantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(currResource))
                {
                    resources[currResource] = 0;
                }

                resources[currResource] += currQuantity;

                currResource = Console.ReadLine();
            }

            foreach (KeyValuePair<string, int> resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
