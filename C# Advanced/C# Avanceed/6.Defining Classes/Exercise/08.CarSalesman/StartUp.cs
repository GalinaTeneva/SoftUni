using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= enginesCount; i++)
            {
                string[] engineTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string engineModel = engineTokens[0];
                int enginePower = int.Parse(engineTokens[1]);

                Engine engine = new Engine(engineModel, enginePower);

                int engineDisplacement = 0;
                string engineEfficiency = string.Empty;

                if (engineTokens.Length == 3)
                {
                    if (int.TryParse(engineTokens[2], out engineDisplacement))
                    {
                        engine.Displacement = int.Parse(engineTokens[2]);
                    }
                    else
                    {
                        engine.Efficiency = engineTokens[2];
                    }
                }
                else if (engineTokens.Length == 4)
                {
                    engine.Displacement = int.Parse(engineTokens[2]);
                    engine.Efficiency = engineTokens[3];
                }

                engines.Add(engine);
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string carModel = carTokens[0];
                string engineModel = carTokens[1];

                Engine engine = engines.Find(e => e.Model == engineModel);
                Car car = new Car(carModel, engine);

                int carWeight = 0;
                string carColour = string.Empty;

                if (carTokens.Length == 3)
                {
                    if (int.TryParse(carTokens[2], out carWeight))
                    {
                        car.Weight = int.Parse(carTokens[2]);
                    }
                    else
                    {
                        car.Colour = carTokens[2];
                    }
                }
                else if (carTokens.Length == 4)
                {
                    car.Weight = int.Parse(carTokens[2]);
                    car.Colour = carTokens[3];
                }

                cars.Add(car);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }
    }
}
