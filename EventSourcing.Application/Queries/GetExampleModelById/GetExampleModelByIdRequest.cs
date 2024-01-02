using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetExampleModelById
{
    public class GetExampleModelByIdRequest : IRequest<GetExampleModelByIdResponse>
    {
        public long Id { get; set; }
    }
}
