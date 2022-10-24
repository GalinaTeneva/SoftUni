using System;

namespace _05._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string accommodationType = string.Empty;
            string location = string.Empty;
            double accommodationPrice = 0;
            if (budget <= 1000)
            {
                accommodationType = "Camp";

                if (season == "Summer")
                {
                    location = "Alaska";
                    accommodationPrice = budget * 0.65;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    accommodationPrice = budget * 0.45;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                accommodationType = "Hut";

                if (season == "Summer")
                {
                    location = "Alaska";
                    accommodationPrice = budget * 0.80;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    accommodationPrice = budget * 0.60;
                }
            }
            else if (budget > 3000)
            {
                accommodationType = "Hotel";

                if (season == "Summer")
                {
                    location = "Alaska";
                    accommodationPrice = budget * 0.90;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    accommodationPrice = budget * 0.90;
                }
            }

            Console.WriteLine($"{location} - {accommodationType} - {accommodationPrice:F2}");
        }
    }
}
