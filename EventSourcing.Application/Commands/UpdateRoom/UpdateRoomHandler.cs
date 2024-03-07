using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateRoom;

public class UpdateRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<UpdateRoomRequest, UpdateUserResponse>
{
    public async Task<UpdateUserResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {   //pobieramhy pokoj  z db
        //zmianmy paramtry
        //zapis do db
        var existingRoom = await _roomRepository.GetAsync(request.Id);

        if(existingRoom == null)
        {
            throw new ArgumentException();
        }

        existingRoom.Name = request.Name;
        existingRoom.Description = request.Description;
        existingRoom.City = request.City;
        existingRoom.Street = request.Street;
        existingRoom.HouseNumber = request.HouseNumber;



        await _roomRepository.UpdateAsync(existingRoom);
        return new UpdateUserResponse() { Success = true };
    }
}
