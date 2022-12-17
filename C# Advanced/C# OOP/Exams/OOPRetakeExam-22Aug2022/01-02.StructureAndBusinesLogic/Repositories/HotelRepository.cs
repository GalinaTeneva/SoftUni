using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private readonly ICollection<IHotel> hotels;

        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }

        public void AddNew(IHotel hotel)
        {
            this.hotels.Add(hotel);
        }
        public IHotel Select(string hotelName)
        {
            return this.hotels.FirstOrDefault(h => h.FullName == hotelName);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return (IReadOnlyCollection<IHotel>)this.hotels;
        }
    }
}
