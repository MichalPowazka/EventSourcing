using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.ChangeRoomStatus;

public class ChangeRoomStatusHandler(IRoomRepository _roomRepository) : IRequestHandler<ChangeRoomStatusRequest, ChangeRoomStatusResponse>
{
   public async Task<ChangeRoomStatusResponse> Handle(ChangeRoomStatusRequest request, CancellationToken cancellationToken)
    {
        var room = await  _roomRepository.GetAsync(request.Id);
        if (room == null)
        {
            return new ChangeRoomStatusResponse()
            {
                IsSuccess = false,
                Message = "Pokój nie istnieje"
            };
        }

        room.IsActive = !room.IsActive;
        await _roomRepository.UpdateAsync(room);

        return new ChangeRoomStatusResponse()
        {
            IsSuccess = true,
            Message = "Zmiana statusu pokoju powiodła się"
        };
    }


}
