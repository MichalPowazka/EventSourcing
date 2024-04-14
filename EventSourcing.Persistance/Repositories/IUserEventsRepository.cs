using EventSourcing.Domain.Events.Users;

namespace EventSourcing.Persistance.Repositories;

public interface IUserEventsRepository
{
    IAsyncEnumerable<UserEvent> GetById(string id);
    Task Save(UserEvent reservationEvent);
    Task CreateStream(UserEvent reservationEvent);

}
