using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking booking)
        {
            this.bookings.Add(booking);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return (IReadOnlyCollection<IBooking>)this.bookings;
        }

        public IBooking Select(string bookingNumberToString)
        {
            return this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);
        }
    }
}
