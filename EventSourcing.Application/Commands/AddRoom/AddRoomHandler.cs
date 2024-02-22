using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddRoom;

public class AddRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<AddRoomRequest, AddRoomResponse>
{
    async Task<AddRoomResponse> IRequestHandler<AddRoomRequest, AddRoomResponse>.Handle(AddRoomRequest request, CancellationToken cancellationToken)
    {
        var room = new Room() {
            Name = request.Name,
            Description = request.Description,
            City = request.City,
            Street = request.Street,
            HouseNumber = request.HouseNumber,
            ApartamentNumber = request.ApartamentNumber,
            PostCode = request.PostCode
        };
        await _roomRepository.AddAsync(room);
        return new AddRoomResponse() { Success = true };
    }
}
