using EventSourcing.Application.Queries.GetRoomById;
using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomAll
{
    public class GetRoomAllHandler(IRoomRepository _roomRepository, IUserContext userContext) : IRequestHandler<GetRoomAllQueryRequest, GetRoomAllResponse>
    {
        public async Task<GetRoomAllResponse> Handle(GetRoomAllQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _roomRepository.GetAllAsync();
            if (result == null)
            {

            }


            return new GetRoomAllResponse()
            {
                ListRooms = result.ToList(),
            };
        }
    }
}
