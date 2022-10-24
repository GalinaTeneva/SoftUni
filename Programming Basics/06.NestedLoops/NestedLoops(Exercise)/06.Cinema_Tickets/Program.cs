using System;

namespace _06.Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalStudentTikets = 0;
            double totalStandartTikets = 0;
            double totalKidTikets = 0;

            while (true)
            {
                string filmName = Console.ReadLine();

                if (filmName == "Finish")
                {
                    break;
                }

                int freeSeats = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();

                double currentMovieTickets = 0;
                int currentMovieStudentTikets = 0;
                int currentMovieStandartTikets = 0;
                int currentMovieKidTikets = 0;

                while (input != "End")
                {
                            currentMovieTickets++;
                    switch (input)
                    {
                        case "student":
                            currentMovieStudentTikets++;
                            break;
                        case "standard":
                            currentMovieStandartTikets++;
                            break;
                        case "kid":
                            currentMovieKidTikets++;
                            break;
                    }

                    if (currentMovieTickets == freeSeats)
                    {
                        break;
                    }

                    input = Console.ReadLine();
                }

                totalStudentTikets += currentMovieStudentTikets;
                totalStandartTikets += currentMovieStandartTikets;
                totalKidTikets += currentMovieKidTikets;

                double currentMovieTakenSeatsPercent = currentMovieTickets / freeSeats * 100;
                Console.WriteLine($"{filmName} - {currentMovieTakenSeatsPercent:F2}% full.");
            }

            double ticketsTotal = totalStudentTikets + totalStandartTikets + totalKidTikets;
            Console.WriteLine($"Total tickets: {ticketsTotal}");

            double totalStudentTiketsPercent = totalStudentTikets / ticketsTotal * 100;
            double totalStandartTiketsPercent = totalStandartTikets / ticketsTotal * 100;
            double totalKidTiketsPercent = totalKidTikets / ticketsTotal * 100;

            Console.WriteLine($"{totalStudentTiketsPercent:F2}% student tickets.");
            Console.WriteLine($"{totalStandartTiketsPercent:F2}% standard tickets.");
            Console.WriteLine($"{totalKidTiketsPercent:F2}% kids tickets.");
        }
    }
}
