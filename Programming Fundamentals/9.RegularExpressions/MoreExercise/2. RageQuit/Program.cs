using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace _2._RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<string>\D+)(?<repeatCount>\d{1,2})";

            MatchCollection matches = Regex.Matches(input, pattern);
            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches)
            {
                string upperCaseSubstring = match.Groups["string"].Value.ToUpper();
                int repeatCount = int.Parse(match.Groups["repeatCount"].Value);
                for (int i = 0; i < repeatCount; i++)
                {
                    sb.Append(upperCaseSubstring);
                }
            }

            char[] sbCharArr = sb.ToString().ToArray();
            List<char> uniqueSymbols = new List<char>();
            foreach (var symbol in sbCharArr)
            {
                if (!uniqueSymbols.Contains(symbol))
                {
                    uniqueSymbols.Add(symbol);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(sb);
        }
    }
}
