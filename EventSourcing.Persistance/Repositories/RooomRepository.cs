using EventSourcing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Persistance.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public RoomRepository(BookingDbContext dbContext)
        {
            _bookingDbContext = dbContext;
        }
        public async Task<int> AddAsync(Room room)
        {
            _bookingDbContext.Add(room);
            await _bookingDbContext.SaveChangesAsync();
            return room.Id;

        }

        public async Task<int> UpdateAsync(Room room)
        {
            _bookingDbContext.Rooms.Update(room);
            await _bookingDbContext.SaveChangesAsync();
            return room.Id;
        }

        public async Task<int> BookingRoom(RoomToReservation roomToReservation)
        {
            var r = await GetAsync(roomToReservation.RoomId);
            r.Reservations.Add(roomToReservation);
            _bookingDbContext.SaveChanges();
            return roomToReservation.Id;

        }

        //DI CONTEXT

        public async Task<Room> GetAsync(int id)
        {   //pobieranie id
            var result = await _bookingDbContext.Rooms.Include(x => x.Reservations).SingleOrDefaultAsync(a => a.Id == id);
            return result;
            //inclue themiclude
        }
    }
}
