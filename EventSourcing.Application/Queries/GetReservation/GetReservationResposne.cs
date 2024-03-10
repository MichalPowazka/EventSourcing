using EventSourcing.Domain.Events.Reservations;

namespace EventSourcing.Application.Queries.GetReservation
{
    public class GetReservationResposne
    {
        public List<ReservationEvent> Reservations { get; set; }  
    }
}
