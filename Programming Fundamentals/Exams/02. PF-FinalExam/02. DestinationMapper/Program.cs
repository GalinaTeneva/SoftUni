using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=|/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);
            string[] destinations = matches.Select(m => m.Groups["destination"].Value).ToArray();
            int travelPoints = destinations.Select(d => d.Length).ToArray().Sum();

            Console.WriteLine($"Destinations: {string.Join(", ", destinations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
