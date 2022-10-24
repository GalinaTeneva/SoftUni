using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitationsList = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command = Console.ReadLine();
            while (command != "Print")
            {
                string[] commandTokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandTokens[0];
                string filterType = commandTokens[1];
                string filterParameter = commandTokens[2];

                if (commandType == "Add filter")
                {
                    filters.Add(filterType + filterParameter, GetPredicate(filterType, filterParameter));
                }
                else
                {
                    filters.Remove(filterType + filterParameter);
                }

                command = Console.ReadLine();
            }

            foreach (var item in filters)
            {
                invitationsList.RemoveAll(item.Value);
            }

            Console.WriteLine(string.Join(' ', invitationsList));
        }

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return default(Predicate<string>);
            }
        }
    }
}
