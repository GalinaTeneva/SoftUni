using System;
using System.Text.RegularExpressions;
namespace _02._MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$|%])(?<tag>[A-Z][a-z]{2,})\1: \[(?<firstNum>\d+)\]\|\[(?<secondNum>\d+)\]\|\[(?<thirdNum>\d+)\]\|$";

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputsCount; i++)
            {
                string currMessage = Console.ReadLine();

                if (Regex.IsMatch(currMessage, pattern))
                {
                    Match match = Regex.Match(currMessage, pattern);

                    string tag = match.Groups["tag"].Value;
                    char firstCode = (char)int.Parse(match.Groups["firstNum"].ToString());
                    char secondCode = (char)int.Parse(match.Groups["secondNum"].Value);
                    char thirdCode = (char)int.Parse(match.Groups["thirdNum"].Value);

                    Console.WriteLine($"{tag}: {firstCode}{secondCode}{thirdCode}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }

        }
    }
}
