using EventSourcing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Persistance.Repositories
{
    public class RoomRepository(BookingDbContext dbContext) : IRoomRepository
    {
        private readonly BookingDbContext _bookingDbContext = dbContext;

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

        public async Task<int> GetAsyncById(int id)
        {
           var room = await _bookingDbContext.Rooms.FindAsync(id);
            return room.Id;
        }
        public async Task<Room> GetAsync(int id)
        {   //pobieranie id
            var result = await _bookingDbContext.Rooms.Include(r=> r.Opinions).SingleOrDefaultAsync(a => a.Id == id);
            return result;
            //inclue themiclude
        }

        public async Task<List<Room>> GetAllAsync()
        {
            var result = await _bookingDbContext.Rooms.Include(x=>x.Images).ToListAsync();
            return result;
        }

        public async Task<int> AddImageAsync(RoomImage image)
        {
            _bookingDbContext.Add(image);
            await _bookingDbContext.SaveChangesAsync();
            return image.Id;
        }

        public async Task<RoomImage> GetImageAsync(int id)
        {
            var result = await _bookingDbContext.RoomImages.SingleOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task DeleteImage(RoomImage image)
        {
            _bookingDbContext.RoomImages.Remove(image);
            await _bookingDbContext.SaveChangesAsync();
        }
    }
}
