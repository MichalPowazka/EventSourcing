using EventSourcing.Application.Dto;
using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomById
{

    public class GetRoomByIdHandler(IRoomRepository _roomRepository, IReseravtionService _reservationService) : IRequestHandler<GetRoomByIdQueryRequest, GetRoomByIdResponse>
    {

       public async Task<GetRoomByIdResponse> Handle(GetRoomByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.GetAsync(request.Id);
            if (result == null) 
            {
                return new GetRoomByIdResponse() 
                {
                    IsSuccess = false,
                };
            }

            return new GetRoomByIdResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                City = result.City,
                Street = result.Street,
                HouseNumber = result.HouseNumber,
                ApartamentNumber = result.ApartamentNumber,
                PostCode = result.PostCode,
                Reservations = await _reservationService.GetReservationsForRoom(result.RoomStream),
                Opinions = result.Opinions,
                RoomStream = result.RoomStream,
                IsSuccess = true
            };
        }
    }
}
