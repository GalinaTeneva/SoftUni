using System;

namespace _03.World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string championshipStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            int ticketsNum = int.Parse(Console.ReadLine());
            char pictureWithTheTrophy = char.Parse(Console.ReadLine());

            double ticketPrice = 0;
            if (championshipStage == "Quarter final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 55.50;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 105.20;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 118.90;
                }
            }
            else if (championshipStage == "Semi final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 75.88;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 125.22;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 300.40;
                }
            }
            else if (championshipStage == "Final")
            {
                if (ticketType == "Standard")
                {
                    ticketPrice = 110.10;
                }
                else if (ticketType == "Premium")
                {
                    ticketPrice = 160.66;
                }
                else if (ticketType == "VIP")
                {
                    ticketPrice = 400;
                }
            }

            double totalCost = ticketPrice * ticketsNum;
            if (totalCost <= 2500)
            {
                if (pictureWithTheTrophy == 'Y')
                {
                    totalCost += ticketsNum * 40;
                }
            }
            else if (totalCost > 2500 && totalCost <= 4000)
            {
                totalCost -= totalCost * 0.1;

                if (pictureWithTheTrophy == 'Y')
                {
                    totalCost += ticketsNum * 40;
                }
            }
            else if (totalCost > 4000)
            {
                totalCost -= totalCost * 0.25;
            }

            
            Console.WriteLine($"{totalCost:F2}");
        }
    }
}
