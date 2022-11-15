
namespace VehiclesExtension.Exceptions
{
    using System;

    public class InsufficientTankSpace : Exception
    {
        public InsufficientTankSpace(string message)
            : base(message)
        {

        }
    }
}
