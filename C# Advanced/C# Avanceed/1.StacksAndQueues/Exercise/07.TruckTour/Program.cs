using System;
using System.Collections.Generic;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpsNum = int.Parse(Console.ReadLine());

            List<string> pumpsList = new List<string>();

            for (int i = 0; i < pumpsNum; i++)
            {
                pumpsList.Add(Console.ReadLine());
            }

            Queue<string> pumpsQueue = new Queue<string>(pumpsList);

            int startPumpIndex = 0;
            while (true)
            {
                int fuilInTheTruck = 0;

                foreach (var item in pumpsQueue)
                {
                    string[] currPumpTokens = item.Split();
                    int currPumpFuel = int.Parse(currPumpTokens[0]);
                    int distanceToNextPump = int.Parse(currPumpTokens[1]);

                    fuilInTheTruck += currPumpFuel;
                    fuilInTheTruck -= distanceToNextPump;

                    if (fuilInTheTruck < 0)
                    {
                        startPumpIndex++;
                        pumpsQueue.Enqueue(pumpsQueue.Dequeue());
                        break;
                    }
                }

                if (fuilInTheTruck >= 0)
                {
                    Console.WriteLine(startPumpIndex);
                    break;
                }
            }

        }
    }
}
