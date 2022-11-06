
namespace Telephony.Exeptions
{
    using System;

    public class InvalidURLException : Exception
    {
        private const string DefaultInvalidURLMessage = "Invalid URL!";

        public InvalidURLException() : base(DefaultInvalidURLMessage)
        {
        }

        public InvalidURLException(string message) : base(message)
        {
        }
    }
}
