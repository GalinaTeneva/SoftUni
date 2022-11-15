
namespace VehiclesExtension.Core
{
    using System;

    using Interfaces;
    using Exceptions;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private IVehicle car;
        private IVehicle truck;
        private IVehicle bus;

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
            double carTankCapacity = double.Parse(carInfo[3]);
            car = new Car(carTankCapacity, carFuelQuantity, carFuelConsumption);

            string[] truckInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double trunkTankCapacity = double.Parse(truckInfo[3]);
            truck = new Truck(trunkTankCapacity, truckFuelQuantity, truckFuelConsumption);

            string[] busInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            bus = new Bus(busTankCapacity, busFuelQuantity, busFuelConsumption); 

            int linesNum = int.Parse(this.reader.ReadLine());

            for (int i = 1; i <= linesNum; i++)
            {
                try
                {
                    string[] commandInfo = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string cmdType = commandInfo[0];
                    string vehicleType = commandInfo[1];
                    double arg = double.Parse(commandInfo[2]);

                    if (cmdType.Contains("Drive"))
                    {
                        if (vehicleType == "Car")
                        {
                            this.writer.WriteLine(car.Drive(arg));
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.writer.WriteLine(truck.Drive(arg));
                        }
                        else if (vehicleType == "Bus")
                        {
                            if (cmdType.Contains("Empty"))
                            {
                                this.writer.WriteLine(bus.DriveEmpty(arg));
                            }
                            else
                            {
                                this.writer.WriteLine(bus.Drive(arg));
                            }
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (arg <= 0)
                        {
                            throw new ArgumentException("Fuel must be a positive number");
                        }

                        if (vehicleType == "Car")
                        {
                            car.Refuel(arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(arg);
                        }
                    }
                }
                catch (InsufficientFuelException ife)
                {
                    this.writer.WriteLine(ife.Message);
                }
                catch (InsufficientTankSpace its)
                {
                    this.writer.WriteLine(its.Message);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            this.writer.WriteLine(car.ToString());
            this.writer.WriteLine(truck.ToString());
            this.writer.WriteLine(bus.ToString());
        }
    }
}
