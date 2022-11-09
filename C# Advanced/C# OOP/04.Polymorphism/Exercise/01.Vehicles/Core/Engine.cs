
namespace Vehicles.Core
{
    using System;

    using Interfaces;
    using IO.Interfaces;
    using Vehicles.Models;
    using Vehicles.Models.Exceptions;
    using Vehicles.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private IVehicle car;
        private IVehicle truck;

        public Engine()
        {
        }

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] carInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            car = new Car(carFuelQuantity, carFuelConsumption);

            string[] truckInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            int linesNum = int.Parse(this.reader.ReadLine());

            for (int i = 1; i <= linesNum; i++)
            {
                try
                {
                    string[] commandInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string cmdType = commandInfo[0];
                    string vehicleType = commandInfo[1];
                    double arg = double.Parse(commandInfo[2]);

                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.writer.WriteLine(car.Drive(arg));
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.writer.WriteLine(truck.Drive(arg));
                        }
                    }
                    else if (cmdType == "Refuel")
                    {

                        if (vehicleType == "Car")
                        {
                            car.Refuel(arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(arg);
                        }
                    }
                }
                catch (InsufficientFuelException ife)
                {
                    this.writer.WriteLine(ife.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            this.writer.WriteLine(car.ToString()); 
            this.writer.WriteLine(truck.ToString()); 
        }
    }
}
