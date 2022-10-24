using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPeople = int.Parse(Console.ReadLine());
            string typeOfTheGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();

            double pricePerPerson = 0;
            double discount = 0;

            if (dayOfTheWeek == "Friday")
            {
                if (typeOfTheGroup == "Students")
                {
                    pricePerPerson = 8.45;

                    if (countOfPeople >= 30)
                    {
                        discount = 0.15;
                    }
                }
                else if (typeOfTheGroup == "Business")
                {
                    pricePerPerson = 10.90;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                    }
                }
                else if (typeOfTheGroup == "Regular")
                {
                    pricePerPerson = 15;

                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        discount = 0.05;
                    }
                }
            }
            else if (dayOfTheWeek == "Saturday")
            {
                if (typeOfTheGroup == "Students")
                {
                    pricePerPerson = 9.80;

                    if (countOfPeople >= 30)
                    {
                        discount = 0.15;
                    }
                }
                else if (typeOfTheGroup == "Business")
                {
                    pricePerPerson = 15.60;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                    }
                }
                else if (typeOfTheGroup == "Regular")
                {
                    pricePerPerson = 20;

                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        discount = 0.05;
                    }
                }
            }
            else if (dayOfTheWeek == "Sunday")
            {
                if (typeOfTheGroup == "Students")
                {
                    pricePerPerson = 10.46;

                    if (countOfPeople >= 30)
                    {
                        discount = 0.15;
                    }
                }
                else if (typeOfTheGroup == "Business")
                {
                    pricePerPerson = 16;

                    if (countOfPeople >= 100)
                    {
                        countOfPeople -= 10;
                    }
                }
                else if (typeOfTheGroup == "Regular")
                {
                    pricePerPerson = 22.50;

                    if (countOfPeople >= 10 && countOfPeople <= 20)
                    {
                        discount = 0.05;
                    }
                }
            }

            double totalPrice = countOfPeople * pricePerPerson - (countOfPeople * pricePerPerson * discount);
            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
