namespace EventSourcing.Domain.Events
{
    public class ReservationEvent
    {
        public int Id { get; set; }
        public Guid Reservation {get; set;}
        public DateTime TimeStamp { get; set; }

    }
}
