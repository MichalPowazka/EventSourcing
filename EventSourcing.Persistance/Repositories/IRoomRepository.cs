using EventSourcing.Domain.Entities;

namespace EventSourcing.Persistance.Repositories;

public interface IRoomRepository
{
    Task<int> AddAsync(Room room);
    Task<int> GetAsyncById(int id);

    Task<int> UpdateAsync(Room room);
    Task<Room> GetAsync(int id);
    Task<int> BookingRoom(RoomToReservation roomToReservation);

}
