using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string inputLine = Console.ReadLine();

            MatchCollection matches = Regex.Matches(inputLine, regex);

            //var validPhones = matches.Cast<Match>().Select(phone => phone.Value.Trim()).ToArray();

            Console.WriteLine(string.Join(", ", matches));


        }
    }
}
