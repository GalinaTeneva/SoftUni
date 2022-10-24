using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%.*<(?<product>\w+)>.*\|(?<count>\d+)\|.*?(?<price>(\d+\.?(\d+)?))\$";
            string input = Console.ReadLine();

            double income = 0;
            while (input != "end of shift")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    int currQuantity = int.Parse(match.Groups["count"].ToString());
                    double currPrice = double.Parse(match.Groups["price"].ToString());
                    double currTotal = currQuantity * currPrice;
                    Console.WriteLine($"{match.Groups["customer"]}: {match.Groups["product"]} - {currTotal:F2}");

                    income += currTotal;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {income:F2}");
        }
    }
}
