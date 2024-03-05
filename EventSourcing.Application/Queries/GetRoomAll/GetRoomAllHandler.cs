using EventSourcing.Application.Queries.GetRoomById;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomAll
{
    public class GetRoomAllHandler(IRoomRepository _roomRepository) : IRequestHandler<GetRoomByIdQueryRequest, GetRoomByIdResponse>
    {
    
    }
}
