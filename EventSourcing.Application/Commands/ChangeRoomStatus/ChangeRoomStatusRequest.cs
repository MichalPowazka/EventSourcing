using MediatR;

namespace EventSourcing.Application.Commands.ChangeRoomStatus;

public class ChangeRoomStatusRequest : IRequest<ChangeRoomStatusResponse>
{
    public int Id { get; set; }
}
