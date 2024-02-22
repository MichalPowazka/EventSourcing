namespace EventSourcing.Domain.Entities;

public class RoomToReservation
{
    public int Id  { get; set; } 
    public Room Room { get; set; }
    public int RoomId { get; set; }
    public string StreamId { get; set; }
}
