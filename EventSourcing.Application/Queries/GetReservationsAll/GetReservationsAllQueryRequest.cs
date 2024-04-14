using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetReservationsAll
{
    public class GetReservationsAllQueryRequest: IRequest<GetReservationsAllResponse>
    {
    }
}
