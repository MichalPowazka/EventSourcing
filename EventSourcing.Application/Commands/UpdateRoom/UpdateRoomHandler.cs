using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateRoom;

public class UpdateRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
{
    public async Task<UpdateRoomResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {   //pobieramhy pokoj  z db
        //zmianmy paramtry
        //zapis do db
        var room = new Room()
        {
            Name = request.Name,
            Description = request.Description,
            City = request.City,
            Street = request.Street,
            HouseNumber = request.HouseNumber,
            ApartamentNumber = request.ApartamentNumber,
            PostCode = request.PostCode
        };
        await _roomRepository.UpdateAsync(room);
        return new UpdateRoomResponse() { Success = true };
    }
}
