using EventSourcing.Domain.Events;

namespace EventSourcing.Persistance.Repositories;

public interface IReservationRepository
{
    IAsyncEnumerable<ReservationEvent> GetById(string id);
    Task Save(ReservationEvent reservationEvent);
    Task Test();
}
