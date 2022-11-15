
namespace VehiclesExtension.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        string Drive(double distance);

        string DriveEmpty (double distance);

        void Refuel(double litters);
    }
}
