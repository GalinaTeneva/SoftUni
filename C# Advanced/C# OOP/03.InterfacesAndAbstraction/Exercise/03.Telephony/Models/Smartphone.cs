
namespace Telephony.Models
{
    using Interfaces;
    using System.Linq;
    using Telephony.Exeptions;

    public class Smartphone : ISmartphone
    {
        public string Browse(string url)
        {
            if (!ValidateURL(url))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            return phoneNumber.All(ch => char.IsDigit(ch));
        }

        private bool ValidateURL(string url)
        {
            return url.All(ch => !char.IsDigit(ch));
        }
    }
}
