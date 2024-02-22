using EventSourcing.Domain.Entities;
using MediatR;

namespace EventSourcing.Application.Queries.GetReservation
{
    public class GetReservationRequest : IRequest<GetReservationResposne>
    {
        public int RoomId { get; set; }    
    }
}
