
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly ICollection<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom room)
        {
            this.rooms.Add(room);
        }
        public IRoom Select(string roomTypeName)
        {
            return this.rooms.FirstOrDefault(r => r.GetType().Name == roomTypeName);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return (IReadOnlyCollection<IRoom>)this.rooms;
        }
    }
}
