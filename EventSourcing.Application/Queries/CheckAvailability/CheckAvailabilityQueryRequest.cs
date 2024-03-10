using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.CheckAvailability
{
    public class CheckAvailabilityQueryRequest : IRequest<CheckAvailabilityResponse>
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; } 
    }
}
