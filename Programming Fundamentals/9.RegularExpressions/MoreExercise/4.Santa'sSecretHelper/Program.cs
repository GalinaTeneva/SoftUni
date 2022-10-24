using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string message = Console.ReadLine();

            List<string> goodChildren = new List<string>();
            while (message != "end")
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < message.Length; i++)
                {
                    char newSymbol = (char)(message[i] - key);
                    sb.Append(newSymbol);
                }

                string decodedMessage = sb.ToString();
                string pattern = @"@(?<name>[A-Za-z]+)[^@|\-|!|:|>]+!(?<behaviour>N|G)!";

                if (Regex.IsMatch(decodedMessage, pattern))
                {
                    Match match = Regex.Match(decodedMessage, pattern);

                    char currChildBehaviour = char.Parse(match.Groups["behaviour"].Value);
                    string currChildName = match.Groups["name"].Value;

                    if (currChildBehaviour == 'G')
                    {
                        goodChildren.Add(currChildName);
                    }

                }

                message = Console.ReadLine();
            }

            foreach (var child in goodChildren)
            {
                Console.WriteLine(child);
            }
        }
    }
}
