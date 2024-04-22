using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddRoom;

public class AddRoomHandler(IRoomRepository _roomRepository, IAggreagte _reservationRepository) : IRequestHandler<AddRoomRequest, AddRoomResponse>
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
            PostCode = request.PostCode,
            RoomStream = Guid.NewGuid().ToString()
        };
        await _roomRepository.AddAsync(room);
        var @event = new ReservationEvent()
        {
            RoomStream = room.RoomStream,
            Type = ReseravatioEventType.Init,
            ReservationUniqueid = room.RoomStream
        };
        await _reservationRepository.CreateStream(@event);

        return new AddRoomResponse() { Success = true };
    }
}
