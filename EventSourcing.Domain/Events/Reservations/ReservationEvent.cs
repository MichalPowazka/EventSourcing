namespace EventSourcing.Domain.Events.Reservations
{
    public class ReservationEvent
    {
        public required string ReservationUniqueid { get; set; }
        public int Id { get; set; }
        public string RoomStream { get; set; }
        public DateTime TimeStamp { get; set; }
        public ReseravatioEventType Type { get; set; }
        public CreateReservationEvenet CreateData { get; set; }
        public UpdateReservationEvent UpdateData { get; set; }
        public CancelReservationEvent CancelData { get; set; }



    }

    public enum ReseravatioEventType
    {
        Create, Update, Cancel, Init
    }

}
