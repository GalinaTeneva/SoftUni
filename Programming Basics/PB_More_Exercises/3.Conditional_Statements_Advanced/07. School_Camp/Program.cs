using System;

namespace _07._School_Camp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int studentsNum = int.Parse(Console.ReadLine());
            int nightsNum = int.Parse(Console.ReadLine());

            double pricePerNight = 0;
            string sport = " ";
            if (season == "Winter")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    pricePerNight = 9.60;

                    if (groupType == "boys")
                    {
                        sport = "Judo";
                    }
                    else if (groupType == "girls")
                    {
                        sport = "Gymnastics";
                    }
                }
                else if (groupType == "mixed")
                {
                    pricePerNight = 10;
                    sport = "Ski";
                }
            }
            else if (season == "Spring")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    pricePerNight = 7.20;

                    if (groupType == "boys")
                    {
                        sport = "Tennis";
                    }
                    else if (groupType == "girls")
                    {
                        sport = "Athletics";
                    }
                }
                else if (groupType == "mixed")
                {
                    pricePerNight = 9.50;
                    sport = "Cycling";
                }
            }
            else if (season == "Summer")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    pricePerNight = 15.00;

                    if (groupType == "boys")
                    {
                        sport = "Football";
                    }
                    else if (groupType == "girls")
                    {
                        sport = "Volleyball";
                    }
                }
                else if (groupType == "mixed")
                {
                    pricePerNight = 20.00;
                    sport = "Swimming";
                }
            }

            double totalCost = studentsNum * pricePerNight * nightsNum;

            double discount = 0;
            if (studentsNum >= 50)
            {
                discount = 0.50;
            }
            else if (studentsNum >= 20 && studentsNum < 50)
            {
                discount = 0.15;
            }
            else if (studentsNum >= 10 && studentsNum < 20)
            {
                discount = 0.05;
            }

            double finalCost = totalCost - (totalCost * discount);
            Console.WriteLine($"{sport} {finalCost:F2} lv.");
        }
    }
}
