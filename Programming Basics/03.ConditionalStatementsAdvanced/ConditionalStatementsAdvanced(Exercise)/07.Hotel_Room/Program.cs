using System;

namespace _07.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int accommodation = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double suitePrice = 0;

            double discountStudio = 0;
            double discountSuite = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                suitePrice = 65;

                if (accommodation > 7 && accommodation <= 14)
                {
                    discountStudio = 0.05;
                }
                else if (accommodation > 14)
                {
                    discountStudio = 0.3;
                    discountSuite = 0.1;
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 75.20;
                suitePrice = 68.70;

                if (accommodation > 14)
                {
                    discountStudio = 0.2;
                    discountSuite = 0.1;
                }
            }
            else if (month == "July" || month == "August")
            {
                studioPrice = 76;
                suitePrice = 77;
                if (accommodation > 14)
                {
                    discountSuite = 0.1;
                }
            }

            double studioPriceTotal = studioPrice * accommodation;
            double finalStudioPrice = studioPriceTotal - studioPriceTotal * discountStudio;
            double suitePriceTotal = suitePrice * accommodation;
            double finalSuitePrice = suitePriceTotal - suitePriceTotal * discountSuite;

            Console.WriteLine($"Apartment: {finalSuitePrice:f2} lv.");
            Console.WriteLine($"Studio: {finalStudioPrice:f2} lv.");
        }
    }
}
