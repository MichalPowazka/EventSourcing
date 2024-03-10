using EventSourcing.Domain.Entities;

namespace EventSourcing.Domain.Events.Reservations;

public class CancelReservationEvent 
{
    public User User { get; set; }
    public string CancelReason { get; set; }
}
