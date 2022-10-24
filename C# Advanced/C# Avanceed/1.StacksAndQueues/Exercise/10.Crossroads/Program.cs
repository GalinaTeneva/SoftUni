using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int passedCarsCounter = 0;
            bool isCrashHappened = false;
            char characterHit = '\0';
            string currCar = string.Empty;

            string input = Console.ReadLine();
            while (input != "END" && isCrashHappened == false)
            {
                if (input == "green")
                {
                    int currGreenLightSecs = greenLightDuration;
                    int currFreeWindow = freeWindowDuration;
                    while (cars.Count > 0)
                    {
                        if (currGreenLightSecs == 0)
                        {
                            break;
                        }

                        currCar = cars.Dequeue();

                        if (currCar.Length > currGreenLightSecs)
                        {
                            if (currCar.Length - currGreenLightSecs > currFreeWindow)
                            {
                                isCrashHappened = true;
                                int characterHitIndex = currCar.Length - (currCar.Length - (currGreenLightSecs + currFreeWindow));
                                characterHit = currCar[characterHitIndex];
                                break;
                            }
                        }

                        passedCarsCounter++;
                        currGreenLightSecs -= currCar.Length;

                        if (currGreenLightSecs <= 0)
                        {
                            currFreeWindow += currGreenLightSecs;
                            currGreenLightSecs = 0;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
                
                input = Console.ReadLine();
            }

            if (isCrashHappened)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{currCar} was hit at {characterHit}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
            }
        }
    }
}
