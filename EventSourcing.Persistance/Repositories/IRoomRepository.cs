using EventSourcing.Domain.Entities;

namespace EventSourcing.Persistance.Repositories;

public interface IRoomRepository
{
    Task<int> AddAsync(Room room);

    Task<int> UpdateAsync(Room room);
    Task<Room> GetAsync(int id);

    Task<List<Room>> GetAllAsync();
    Task<int> AddImageAsync(RoomImage room);
    Task<RoomImage> GetImageAsync(int id);
    Task DeleteImage(RoomImage image);


}
