using EventSourcing.Domain.Events;

namespace EventSourcing.Persistance.Repositories;

public interface IReservationRepository
{
    IAsyncEnumerable<ReservationEvent> GetById(int id);
    Task Save(ReservationEvent reservationEvent);
    Task Test();
}
