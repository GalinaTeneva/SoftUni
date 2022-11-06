
namespace Telephony.Models
{
    using Interfaces;
    using System.Linq;
    using Telephony.Exeptions;

    public class StationaryPhone : IStationaryPhone
    {
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(ch => char.IsDigit(ch));
        }
    }
}
