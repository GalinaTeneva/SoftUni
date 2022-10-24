using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] commandTokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = commandTokens[0];

                if (action == "Party!")
                {
                    break;
                }

                string filter = commandTokens[1];
                string value = commandTokens[2];

                if (action == "Remove")
                {
                    guests.RemoveAll(GetPredicate(filter, value));
                }
                else if (action == "Double")
                {
                    List<string> guestsToDouble = guests.FindAll(GetPredicate(filter, value));

                    int index = guests.FindIndex(GetPredicate(filter, value));
                    if (index >= 0)
                    {
                        guests.InsertRange(index, guestsToDouble);
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            if (filter == "StartsWith")
            {
                return s => s.StartsWith(value);
            }
            else if (filter == "EndsWith")
            {
                return s => s.EndsWith(value);
            }
            else if (filter == "Length")
            {
                return s => s.Length == int.Parse(value);
            }

            return default(Predicate<string>);
        }
    }
}
