using MediatR;

namespace EventSourcing.Application.Commands.CancelReservation;

public class CancelReservationRequest : IRequest<int>
{
    public string Id {  get; set; }
    public string ResolveDescription { get; set; }

}
