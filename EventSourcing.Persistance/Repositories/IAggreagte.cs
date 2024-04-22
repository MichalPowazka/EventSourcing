using EventSourcing.Domain.Events.Reservations;

namespace EventSourcing.Persistance.Repositories;

public interface IAggreagte 

{
    IAsyncEnumerable<ReservationEvent> GetById(string id);
    Task Save(ReservationEvent reservationEvent);
    Task CreateStream(ReservationEvent reservationEvent);

}
