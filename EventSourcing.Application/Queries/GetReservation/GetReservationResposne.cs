using EventSourcing.Application.Dto;
using EventSourcing.Domain.Events.Reservations;

namespace EventSourcing.Application.Queries.GetReservation
{
    public class GetReservationResposne
    {
        public List<ReservationDto> Reservations { get; set; }  
    }
}
