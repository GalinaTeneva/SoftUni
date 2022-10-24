using System;

namespace _01.Excursion
{
    class Program
    {
        static void Main(string[] args)
        {
            double pricePerNight = 20;
            double seasonTicketPrice = 1.60;
            double museumTicketPrice = 6;
            double additionalCostsPercent = 0.25;

            int peopleInGroup = int.Parse(Console.ReadLine());
            int nightsNum = int.Parse(Console.ReadLine());
            int seasonTicketsNum = int.Parse(Console.ReadLine());
            int museumTicketsNum = int.Parse(Console.ReadLine());

            double totalForAccomodation = nightsNum * pricePerNight * peopleInGroup;
            double totalForSeasonTickets = seasonTicketsNum * seasonTicketPrice * peopleInGroup;
            double totalForMuseumTickets = museumTicketsNum * museumTicketPrice * peopleInGroup;
            double totalPriceForTheTrip = totalForAccomodation + totalForSeasonTickets + totalForMuseumTickets;
            double additionalCostsAmount = totalPriceForTheTrip * additionalCostsPercent;
            double finalPriceForTheTrip = totalPriceForTheTrip + additionalCostsAmount;

            Console.WriteLine($"{finalPriceForTheTrip:F2}");
        }
    }
}
