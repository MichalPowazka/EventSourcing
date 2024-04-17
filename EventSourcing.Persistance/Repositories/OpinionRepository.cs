using EventSourcing.Domain.Entities;

namespace EventSourcing.Persistance.Repositories
{

    public class OpinionRepository(BookingDbContext _bookingDbContext) : IOpinionRepository
    {
        public async Task<int> AddAsync(Opinion room)
        {
            _bookingDbContext.Add(room);
            await _bookingDbContext.SaveChangesAsync();
            return room.Id;
        }

        public Task<List<Opinion>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Opinion> GetAsync(int id)
        {
            var opinion = await _bookingDbContext.Opinion.FindAsync(id);
            return opinion;
        }

        public async Task<int> UpdateAsync(Opinion opinion)
        {

            _bookingDbContext.Opinion.Update(opinion);
           await _bookingDbContext.SaveChangesAsync();
            return opinion.Id;
        }
    }
}
