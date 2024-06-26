﻿using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateRoom;

public class UpdateRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<UpdateRoomRequest, UpdateRoomResponse>
{
    public async Task<UpdateRoomResponse> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {   
        var existingRoom = await _roomRepository.GetAsync(request.Id);

        if(existingRoom == null)
        {
            return new UpdateRoomResponse()
            {
                Success = false

            };
        }

        existingRoom.Name = request.Name;
        existingRoom.Description = request.Description;
        existingRoom.City = request.City;
        existingRoom.Street = request.Street;
        existingRoom.HouseNumber = request.HouseNumber;

        await _roomRepository.UpdateAsync(existingRoom);
        return new UpdateRoomResponse() { Success = true };
    }
}
