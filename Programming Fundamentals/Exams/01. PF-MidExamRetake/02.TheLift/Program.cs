using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxPeoplePerWagon = 4;
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int fullWagonsCounter = 0;
            bool isLiftFull = false;
            while (peopleWaiting > 0)
            {
                for (int currWagon = 0; currWagon < wagons.Length; currWagon++)
                {
                    if (wagons[currWagon] < maxPeoplePerWagon)
                    {
                        int freeSeats = maxPeoplePerWagon - wagons[currWagon];
                        if (freeSeats <= peopleWaiting)
                        {
                            wagons[currWagon] += freeSeats;
                            peopleWaiting -= freeSeats;
                        }
                        else
                        {
                            wagons[currWagon] += peopleWaiting;
                            peopleWaiting -= peopleWaiting;
                        }
                    }
                    if (wagons[currWagon] == maxPeoplePerWagon)
                    {
                        fullWagonsCounter++;
                        if (fullWagonsCounter == wagons.Length)
                        {
                            isLiftFull = true;
                        }
                    }
                }

                if (isLiftFull && peopleWaiting > 0)
                {
                    Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                    break;
                }
                else if (!isLiftFull && peopleWaiting <= 0)
                {
                    Console.WriteLine("The lift has empty spots!");
                }
            }

            Console.WriteLine(string.Join(" ", wagons));

        }
    }
}
