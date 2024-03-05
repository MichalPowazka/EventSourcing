using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetRoomById
{
    public class GetRoomByIdQueryRequest : IRequest<GetRoomByIdResponse>
    {
       public int Id { get; set; }
       
    }
}
