using EventSourcing.Domain.Entities;

namespace EventSourcing.Domain.Events
{
    public class UpdateReservationEvent : ReservationEvent
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public User User { get; set; }
    }
}
