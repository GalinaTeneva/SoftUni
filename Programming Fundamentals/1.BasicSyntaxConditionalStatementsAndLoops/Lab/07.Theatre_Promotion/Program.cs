using System;

namespace _07.Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int ageOfThePerson = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            if (ageOfThePerson >= 0 && ageOfThePerson <= 18)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    ticketPrice = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    ticketPrice = 5;
                }
            }
            else if (ageOfThePerson > 18 && ageOfThePerson <= 64)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice = 18;
                }
                else if (typeOfDay == "Weekend")
                {
                    ticketPrice = 20;
                }
                else if (typeOfDay == "Holiday")
                {
                    ticketPrice = 12;
                }
            }
            else if (ageOfThePerson > 64 && ageOfThePerson <= 122)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice = 12;
                }
                else if (typeOfDay == "Weekend")
                {
                    ticketPrice = 15;
                }
                else if (typeOfDay == "Holiday")
                {
                    ticketPrice = 10;
                }
            }
            else
            {
                Console.WriteLine("Error!");
                return;
            }

            Console.WriteLine($"{ticketPrice}$");
        }
    }
}
