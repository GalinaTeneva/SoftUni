using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersByForce = new Dictionary<string, SortedSet<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                if (input.Contains('|'))
                {
                    string[] inputTokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = inputTokens[0];
                    string user = inputTokens[1];

                    if (!usersByForce.Values.Any(x => x.Contains(user)))
                    {
                        if (!usersByForce.ContainsKey(side))
                        {
                            usersByForce[side] = new SortedSet<string>();
                        }

                        usersByForce[side].Add(user);
                    }
                }
                else
                {
                    string[] inputTokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string user = inputTokens[0];
                    string side = inputTokens[1];

                    foreach (var pair in usersByForce)
                    {
                        if (pair.Value.Contains(user))
                        {
                            pair.Value.Remove(user);
                            break;
                        }
                    }

                    if (!usersByForce.ContainsKey(side))
                    {
                        usersByForce[side] = new SortedSet<string>();
                    }

                    usersByForce[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var orderedUsersByForce = usersByForce.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);
            foreach (var kvp in orderedUsersByForce)
            {
                if (kvp.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                    foreach (var pair in kvp.Value)
                    {
                        Console.WriteLine($"! {pair}");
                    }
                }
            }
        }
    }
}
