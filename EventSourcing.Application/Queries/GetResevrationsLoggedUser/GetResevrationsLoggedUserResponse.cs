using EventSourcing.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetResevrationsLoggedUser
{
    public class GetResevrationsLoggedUserResponse
    {
        public List<ReservationDto> Reservations { get; set; }
    }
}
