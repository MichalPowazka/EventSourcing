using MediatR;

namespace EventSourcing.Application.Commands.CancelReservation;

public class CancelReservationRequest : IRequest<CancelReservationResponse>
{
    public string ReservationUniqueId { get; set; }
    public string RoomStreamId { get; set; }
    public string Id {  get; set; }
    public string ResolveDescription { get; set; }

}
