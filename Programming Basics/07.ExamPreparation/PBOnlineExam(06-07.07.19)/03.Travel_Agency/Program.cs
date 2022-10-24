using System;

namespace _03.Travel_Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            string town = Console.ReadLine();
            string reservationType = Console.ReadLine();
            string isDiscount = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            if (days > 7)
            {
                days--;
            }

            double reservationPricePerDay = 0;
            double discountPercent = 0;

            if (town == "Bansko" || town == "Borovets")
            {
                switch (reservationType)
                {
                    case "noEquipment":
                        reservationPricePerDay = 80;
                        if (isDiscount == "yes")
                        {
                            discountPercent = 0.05;
                        }
                        break;
                    case "withEquipment":
                        reservationPricePerDay = 100;
                        if (isDiscount == "yes")
                        {
                            discountPercent = 0.1;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        return;
                }
            }
            else if (town == "Varna" || town == "Burgas")
            {
                switch (reservationType)
                {
                    case "noBreakfast":
                        reservationPricePerDay = 100;
                        if (isDiscount == "yes")
                        {
                            discountPercent = 0.07;
                        }
                        break;
                    case "withBreakfast":
                        reservationPricePerDay = 130;
                        if (isDiscount == "yes")
                        {
                            discountPercent = 0.12;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return;
            }
            
            double totalReservationPrice = days * reservationPricePerDay;
            double discountAmmount = totalReservationPrice * discountPercent;
            double finalPrice = totalReservationPrice - discountAmmount;

            Console.WriteLine($"The price is {finalPrice:F2}lv! Have a nice time!");
        }
    }
}
