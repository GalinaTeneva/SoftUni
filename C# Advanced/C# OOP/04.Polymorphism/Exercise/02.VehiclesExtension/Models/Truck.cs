
using VehiclesExtension.Exceptions;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionIncrement = 1.6;

        public Truck(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double ConsumptionIncrement => FuelConsumptionIncrement;

        public override void Refuel(double liters)
        {
            double tankFreeSpace = TankCapacity - FuelQuantity;
            double litersAfterReduction = liters * 0.95;

            if (litersAfterReduction > tankFreeSpace)
            {
                throw new InsufficientTankSpace(string.Format(ExceptionMessages.InsufficientTankSpaceMessage, liters));
            }

            FuelQuantity += litersAfterReduction;
        }
    }
}
