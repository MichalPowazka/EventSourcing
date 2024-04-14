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
   /* public class GetReservationsAllHandler(IReseravtionService reservationRepository, IRoomRepository roomRepository) : IRequestHandler<GetReservationsAllQueryRequest, GetReservationsAllResponse>
    {
        private readonly IReservationRepository _reservationRepository = reservationRepository;
        private readonly IRoomRepository _roomRepository = roomRepository;
        public async Task<GetReservationsAllResponse> Handle(GetReservationsAllQueryRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var roomReservations = new List<ReservationDto>();

            foreach (var room in rooms)
            {
                
            }
        }
    }*/
}
