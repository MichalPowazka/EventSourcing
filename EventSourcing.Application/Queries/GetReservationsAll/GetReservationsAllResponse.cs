using EventSourcing.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetReservationsAll
{
    public class GetReservationsAllResponse
    {
        public List<ReservationDto> Reservations { get; set; }
    }
}
