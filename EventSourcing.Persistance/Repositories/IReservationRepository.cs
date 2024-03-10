using EventSourcing.Domain.Events.Reservations;

namespace EventSourcing.Persistance.Repositories;

public interface IReservationRepository
{
    IAsyncEnumerable<ReservationEvent> GetById(string id);
    Task Save(ReservationEvent reservationEvent);
    Task Test();
}
