using EventSourcing.Application.Dto;
using EventSourcing.Application.Queries.GetReservation;
using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetReservationsAll
{
    public class GetReservationsAllHandler(IReseravtionService _reservationService, IRoomRepository _roomRepository) : IRequestHandler<GetReservationsAllQueryRequest, GetReservationsAllResponse>
    { 
        public async Task<GetReservationsAllResponse> Handle(GetReservationsAllQueryRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var allReservations = new List<ReservationDto>();

            foreach (var room in rooms)
            {
                var reservations = await _reservationService.GetReservationsForRoom(room.RoomStream);
                allReservations.AddRange(reservations);
            }

            return new GetReservationsAllResponse()
            {
                Reservations = allReservations
            };
        }
    }
}
