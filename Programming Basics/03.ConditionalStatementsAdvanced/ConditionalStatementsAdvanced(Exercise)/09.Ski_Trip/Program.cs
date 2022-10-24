using System;

namespace _09.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string accommodationType = Console.ReadLine();
            string rating = Console.ReadLine();

            int nights = days - 1;
            double pricePerNight = 0;
            double discount = 0;
            double finalPrice = 0;

            switch (accommodationType)
            {
                case "room for one person":
                    pricePerNight = 18;
                    break;
                case "apartment":
                    pricePerNight = 25;

                    if (days < 10)
                    {
                        discount = 0.3;
                    }
                    else if (days > 10 && days < 15)
                    {
                        discount = 0.35;
                    }
                    else if (days > 15)
                    {
                        discount = 0.5;
                    }
                    break;
                case "president apartment":
                    pricePerNight = 35;

                    if (days < 10)
                    {
                        discount = 0.1;
                    }
                    else if (days > 10 && days < 15)
                    {
                        discount = 0.15;
                    }
                    else if (days > 15)
                    {
                        discount = 0.2;
                    }
                    break;
            }

            double priceWithoutDiscount = nights * pricePerNight;
            double priceWithDiscount = priceWithoutDiscount - priceWithoutDiscount * discount;

            if (rating == "positive")
            {
                finalPrice = priceWithDiscount + priceWithDiscount * 0.25;
            }
            else if (rating == "negative")
            {
                finalPrice = priceWithDiscount - priceWithDiscount * 0.1;
            }

            Console.WriteLine($"{finalPrice:f2}");
        }
    }
}
