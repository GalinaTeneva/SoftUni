using System;
using System.Text.RegularExpressions;
namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string validBarcodePattern = @"@#+(?<product>[A-Z][A-Za-z\d]{4,}[A-Z])@#+";
            string digitsPattern = @"\d";

            int barcodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= barcodesCount; i++)
            {
                string currBarcode = Console.ReadLine();
                if (Regex.IsMatch(currBarcode, validBarcodePattern))
                {
                    MatchCollection digits = Regex.Matches(currBarcode, digitsPattern);
                    string currGroup = digits.Count == 0 ? "00" : string.Join("", digits);

                    Console.WriteLine($"Product group: {currGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
