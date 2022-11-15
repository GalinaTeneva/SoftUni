
namespace VehiclesExtension.Models
{
    using Exceptions;
    using Interfaces;
    using System;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsimption;
        private double tankCapacity;

        public Vehicle(double tankCapacity, double fuelQuantity, double fuelConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double ConsumptionIncrement { get; }

        public double FuelQuantity
        {
            get
            {
                return fuelQuantity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                if (value > TankCapacity)
                {
                    value = 0;
                }

                fuelQuantity = value;
            }
        }

        public double FuelConsumption
        {
            get
            {
                return fuelConsimption;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                fuelConsimption = value + ConsumptionIncrement;
            }
        }

        public double TankCapacity
        {
            get
            {
                return tankCapacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                tankCapacity = value;
            }
        }

        public string Drive(double distance)
        {
            if (distance * FuelConsumption > FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelMessage, this.GetType().Name));
            }

            FuelQuantity -= distance * FuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            double emptyVehicleFuelConsumption = FuelConsumption - ConsumptionIncrement;

            if (distance * emptyVehicleFuelConsumption > FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelMessage, this.GetType().Name));
            }

            FuelQuantity -= distance * emptyVehicleFuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            double tankFreeSpace = TankCapacity - FuelQuantity;

            if (liters > tankFreeSpace)
            {
                throw new InsufficientTankSpace(string.Format(ExceptionMessages.InsufficientTankSpaceMessage, liters));
            }

            FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
