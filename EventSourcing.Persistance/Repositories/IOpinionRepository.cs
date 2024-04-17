using EventSourcing.Domain.Entities;

namespace EventSourcing.Persistance.Repositories
{
    public interface IOpinionRepository
    {
        Task<int> AddAsync(Opinion room);
        Task<List<Opinion>> GetAllAsync();  
        Task<int> UpdateAsync(Opinion room);
        Task<Opinion> GetAsync(int id);
    }
}
