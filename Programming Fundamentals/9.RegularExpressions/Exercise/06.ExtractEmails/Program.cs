using System;
using System.Text.RegularExpressions;

namespace _06.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string emailPattern = @"(^|\s)(?<user>[A-Za-z0-9][\w*\.\-_]+)@(?<host>[a-z\-]+\.[a-z\-]+(\.[a-z\-]+)*)";
            string inputText = Console.ReadLine();

            MatchCollection emails = Regex.Matches(inputText, emailPattern);

            foreach (Match email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
