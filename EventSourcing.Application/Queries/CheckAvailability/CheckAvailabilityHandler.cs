using EventSourcing.Application.Dto;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventSourcing.Application.Queries.CheckAvailability
{
    public class CheckAvailabilityHandler(IReservationRepository _reservationRepository, IRoomRepository _roomRepository) : IRequestHandler<CheckAvailabilityQueryRequest, CheckAvailabilityResponse>
    {
        public async Task<CheckAvailabilityResponse> Handle(CheckAvailabilityQueryRequest request, CancellationToken cancellationToken)
        {
            var res = true;
            var reservationList = new List<ReservationDto>();
            var room = await _roomRepository.GetAsync(request.Id);
            //pobrac rezewacje pokoju
            foreach (var reservation in room.Reservations)
            {
                if (!(await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).Any(x => x.Type == ReseravatioEventType.Cancel))
                {
                    if (!(await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).Any(x => x.Type == ReseravatioEventType.Update))
                    {
                        reservationList.Add(new ReservationDto()
                        {
                            DateFrom = ((await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).First().CreateData).DateFrom,
                            DateTo = ((await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).First().CreateData).DateTo


                        });
                    }
                    else
                    {

                        reservationList.Add(new ReservationDto()
                        {
                            DateFrom = ((await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).Last().UpdateData).DateFrom,
                            DateTo = ((await _reservationRepository.GetById(reservation.StreamId).ToListAsync()).Last().UpdateData).DateTo


                        });
                    }

                }
            }
            var overlappingReservations = reservationList.Any(x =>
                 (request.DateFrom >= x.DateFrom && request.DateFrom <= x.DateTo) ||   // data początkowa wewnątrz istniejącej rezerwacji
                 (request.DateTo >= x.DateFrom && request.DateTo <= x.DateTo) ||       // data końcowa wewnątrz istniejącej rezerwacji
                 (request.DateFrom <= x.DateFrom && request.DateTo >= x.DateTo)        // cała rezerwacja obejmuje istniejącą rezerwację
                );
            res = !overlappingReservations;
            return new CheckAvailabilityResponse()
            {
                Available = res
            };
        }
    }
}
