
namespace Telephony.Core
{
    using System;

    using Interfaces;
    using Telephony.Exeptions;
    using Telephony.IO.Interfaces;
    using Telephony.Models;
    using Telephony.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IStationaryPhone stationaryPhone;
        private readonly ISmartphone smartphone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartphone = new Smartphone();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string[] phoneNumbers = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    if (phoneNumber.Length == 10)
                    {
                        this.writer.WriteLine(this.smartphone.Call(phoneNumber));
                    }
                    else if (phoneNumber.Length == 7)
                    {
                        this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                    }
                    else
                    {
                        throw new InvalidPhoneNumberException();
                    }
                }
                catch (InvalidPhoneNumberException ipne)
                {
                    this.writer.WriteLine(ipne.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (string url in urls)
            {
                try
                {
                    this.writer.WriteLine(this.smartphone.Browse(url));
                }
                catch (InvalidURLException iue)
                {
                    this.writer.WriteLine(iue.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
