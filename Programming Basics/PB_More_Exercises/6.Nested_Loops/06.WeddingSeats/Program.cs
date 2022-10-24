using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsInTheFirstSector = int.Parse(Console.ReadLine());
            int totalSeatsInAOddRow = int.Parse(Console.ReadLine());

            int totalSeatsInEvenRow = totalSeatsInAOddRow + 2;
            int totalSeatsCounter = 0;

            int sectorsCounter = 0;
            for (int currentSector = (int)'A'; currentSector <= (int)lastSector; currentSector++)
            {
                sectorsCounter++;
                int rowsInCurrentSector = 0;
                if (currentSector == (int)'A')
                {
                    rowsInCurrentSector = rowsInTheFirstSector;
                }
                else
                {
                    rowsInCurrentSector = rowsInTheFirstSector + sectorsCounter - 1;
                }

                for (int currentRow = 1; currentRow <= rowsInCurrentSector; currentRow++)
                {
                    int seatsInCurrentRow = 0;
                    if (currentRow % 2 == 0)
                    {
                        seatsInCurrentRow = totalSeatsInEvenRow;
                    }
                    else
                    {
                        seatsInCurrentRow = totalSeatsInAOddRow;
                    }

                    for (int currentSeatIndex = 0; currentSeatIndex < seatsInCurrentRow; currentSeatIndex++)
                    {
                        int currentSeat = (int)'a' + currentSeatIndex;

                        Console.WriteLine($"{(char)currentSector}{currentRow}{(char)currentSeat}");
                        totalSeatsCounter++;
                    }
                }
            }

            Console.WriteLine(totalSeatsCounter);
        }
    }
}
