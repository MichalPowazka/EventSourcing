using EventSourcing.Domain.Entities;

namespace EventSourcing.Domain.Events.Reservations
{
    public class UpdateReservationEvent
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User User { get; set; }
    }
}
