using Azure.Core;
using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Dto;
using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;

namespace EventSourcing.Application.Services;

public class ReservationService(IRoomRepository _roomRepository, IReservationRepository _reservationRepository) : IReseravtionService
{
    public async Task<bool> AddReservation(AddBookingRequest request, Room room)
    {
        try
        {
            var @event = new ReservationEvent()
            {
                Id = request.Id,
                Reservation = Guid.NewGuid(),
                Type = ReseravatioEventType.Create,
                CreateData = new CreateReservationEvenet()
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                },

            };

            room.ControlValue = new Guid().ToString();
            await _roomRepository.UpdateAsync(room);
            await _roomRepository.BookingRoom(new Domain.Entities.RoomToReservation()
            {
                RoomId = request.RoomId,
                StreamId = @event.Reservation.ToString(),
            });
            return true;
        }catch
        {
            return false;
        }


    }

    public async Task<bool> IsAvaible(int roomId, DateTime dateFrom, DateTime dateTo)
    {
        var res = true;
        var reservationList = new List<ReservationDto>();
        var room = await _roomRepository.GetAsync(roomId);
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
        (dateFrom >= x.DateFrom && dateFrom <= x.DateTo) ||   // data początkowa wewnątrz istniejącej rezerwacji
        (dateTo >= x.DateFrom && dateTo <= x.DateTo) ||       // data końcowa wewnątrz istniejącej rezerwacji
        (dateFrom <= x.DateFrom && dateTo >= x.DateTo)        // cała rezerwacja obejmuje istniejącą rezerwację
            );
        res = !overlappingReservations;

        return res;
    }
}