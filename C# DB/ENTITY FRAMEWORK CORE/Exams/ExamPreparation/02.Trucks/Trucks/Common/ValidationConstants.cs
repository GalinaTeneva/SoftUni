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
        public const int DespatcherMinLength = 2;

        //Truck
        public const int TruckRegistrationNumberLength = 8;
        public const int TruckVinNumberLength = 17;

    }
}
