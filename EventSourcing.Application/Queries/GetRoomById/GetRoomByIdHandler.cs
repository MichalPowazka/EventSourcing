using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomById
{

    public class GetRoomByIdHandler(IRoomRepository _roomRepository) : IRequestHandler<GetRoomByIdQueryRequest, GetRoomByIdResponse>
    {

       public async Task<GetRoomByIdResponse> Handle(GetRoomByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.GetAsync(request.Id);
            if (result == null) 
            {

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
                Reservations = result.Reservations,
                Opinions = result.Opinions
            };
        }
    }
}
