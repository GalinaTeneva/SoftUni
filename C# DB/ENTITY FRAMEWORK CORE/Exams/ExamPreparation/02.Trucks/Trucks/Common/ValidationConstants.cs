namespace Trucks.Common
{
    public static class ValidationConstants
    {
        //Client
        public const int ClientNameMaxLength = 40;
        public const int ClientNameMinLength = 3;

        public const int ClientNationalityMaxLength = 40;
        public const int ClientNationalityMinLength = 2;

        //Despatcher
        public const int DespatcherNameMaxLength = 40;
        public const int DespatcherNameMinLength = 2;

        //Truck
        public const int TruckRegistrationNumberLength = 8;
        public const int TruckVinNumberLength = 17;
        public const string TruckRegistrationRegEx = @"[A-Z]{2}\d{4}[A-Z]{2}";
        public const int TruckTankCapacityMinValue = 950;
        public const int TruckTankCapacityMaxValue = 1420;
        public const int TruckCargoCapacityMinValue = 5000;
        public const int TruckCargoCapacityMaxValue = 29000;
        public const int TruckCategoryTypeMinValue = 0;
        public const int TruckCategoryTypeMaxValue = 3;
        public const int TruckMakeTypeMinValue = 0;
        public const int TruckMakeTypeMaxValue = 4;

    }
}
