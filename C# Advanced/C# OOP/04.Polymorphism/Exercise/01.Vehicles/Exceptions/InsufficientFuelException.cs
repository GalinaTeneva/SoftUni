
namespace Vehicles.Models.Exceptions
{
    using System;

    public class InsufficientFuelException : Exception
    {
        public InsufficientFuelException(string message)
            : base (message)
        {

        }
    }
}
