using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] currCarInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = currCarInfo[0];
                double fuelAmount = int.Parse(currCarInfo[1]);
                double fuelConsumptionPerKilometer = double.Parse(currCarInfo[2]);

                carsList.Add(new Car(model, fuelAmount, fuelConsumptionPerKilometer));
            }

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdTokens = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = cmdTokens[1];
                double amountOfKm = double.Parse(cmdTokens[2]);

                Car car = carsList.Find(c => c.Model == carModel);
                car.Drive(amountOfKm);
            }

            foreach (Car car in carsList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistace}");

            }

        }
    }
}
