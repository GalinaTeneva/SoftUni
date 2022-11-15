
namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionIncrement = 0.9;

        public Car(double tankCapacity, double fuelQuantity, double fuelConsumption)
            : base(tankCapacity, fuelQuantity, fuelConsumption)
        {
        }

        public override double ConsumptionIncrement => FuelConsumptionIncrement;
    }
}
