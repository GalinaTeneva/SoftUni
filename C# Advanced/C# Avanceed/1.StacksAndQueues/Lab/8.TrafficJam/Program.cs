using System;
using System.Collections.Generic;

namespace _8.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerSingleGreenLight = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            Queue<string> waitingCars = new Queue<string>();
            int totalCarsPassed = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 1; i <= carsPerSingleGreenLight; i++)
                    {
                        if (waitingCars.Count > 0)
                        {
                            Console.WriteLine($"{waitingCars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    waitingCars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
