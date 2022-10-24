using System;
using System.Text.RegularExpressions;

namespace _01._WinningTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] splitSymbols = new char[] { ',', ' ' };
            string[] tickets = Console.ReadLine().Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"(?<symbol>[@|#|$|^])\k<symbol>{5,}";

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string substringOne = ticket.Substring(0, 10);
                string substringTwo = ticket.Substring(10, 10);

                if (Regex.IsMatch(substringOne, pattern) && Regex.IsMatch(substringTwo, pattern))
                {
                    Match matchOne = Regex.Match(substringOne, pattern);
                    Match matchTwo = Regex.Match(substringTwo, pattern);
                    char symbol = char.Parse(matchOne.Groups["symbol"].Value);
                    int minLength = Math.Min(matchOne.Length, matchTwo.Length);

                    string matchOneSubstring = matchOne.Value.Substring(0, minLength);
                    string matchTwoSubstring = matchTwo.Value.Substring(0, minLength);
                    if (matchOneSubstring == matchTwoSubstring)
                    {
                        if (matchOneSubstring.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {matchOne.Length}{symbol} Jackpot!");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {minLength}{symbol}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }
            }
        }
    }
}
