using EventSourcing.Application.Commands.AddBooking;
using EventSourcing.Application.Dto;
using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;

namespace EventSourcing.Application.Services;

public class ReservationService(IRoomRepository _roomRepository, IAggreagte<ReservationEvent> _reservationRepository, IUserContext _userContext) : IReseravtionService
{

    public async Task<bool> AddReservation(AddBookingRequest request, Room room)
    {
        try
        {
            var @event = new ReservationEvent()
            {
                Id = request.Id,
                ReservationUniqueid = Guid.NewGuid().ToString(),
                RoomStream = request.RoomStreamId,
                Type = ReseravatioEventType.Create,
                CreateData = new CreateReservationEvenet()
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    User = await _userContext.GetCurrentUser()
                },

            };
            await _reservationRepository.Save(@event);
            room.ControlValue = new Guid().ToString();
            await _roomRepository.UpdateAsync(room);

            return true;
        }
        catch (Exception)
        {
            return false;
        }


    }

    public async Task<List<ReservationDto>> GetReservationsForRoom(string roomStream)
    {
        var result = new List<ReservationDto>();
        var reservationEvents = (await _reservationRepository.GetById(roomStream).ToListAsync()).GroupBy(x => x.ReservationUniqueid).ToList();
        reservationEvents = reservationEvents.Where(x => !x.Any(x => x.Type == ReseravatioEventType.Cancel)).ToList();

        foreach (var resevation in reservationEvents)
        {
            var lastEvent = resevation.Last();
            if (lastEvent.Type == ReseravatioEventType.Create)
            {
                result.Add(new ReservationDto()
                {
                    DateFrom = lastEvent.CreateData.DateFrom,
                    DateTo = lastEvent.CreateData.DateTo,
                    ReservationUniqueId = resevation.Key,
                    User = lastEvent.CreateData.User
                });
            }

            if (lastEvent.Type == ReseravatioEventType.Update)
            {
                result.Add(new ReservationDto()
                {
                    DateFrom = lastEvent.UpdateData.DateFrom,
                    DateTo = lastEvent.UpdateData.DateTo,
                    ReservationUniqueId = resevation.Key,
                    User = lastEvent.UpdateData.User
                });
            }
        }
        return result;
    }

    public async Task<bool> IsAvaible(int roomId, DateTime dateFrom, DateTime dateTo)
    {
        var res = true;
        var reservationList = new List<ReservationDto>();
        var room = await _roomRepository.GetAsync(roomId);
        reservationList = await GetReservationsForRoom(room.RoomStream);
        dateFrom = dateFrom.AddHours(0 - dateFrom.Hour);
        dateFrom = dateFrom.AddMinutes(0 - dateFrom.Minute);
        dateFrom = dateFrom.AddSeconds(0 - dateFrom.Second);

        dateTo = dateTo.AddHours(23 - dateTo.Hour);
        dateTo = dateTo.AddMinutes(59 - dateTo.Minute);
        dateTo = dateTo.AddSeconds(59 - dateTo.Second);


        var overlappingReservations = reservationList.Any(x =>
        (dateFrom >= x.DateFrom && dateFrom <= x.DateTo) ||   
        (dateTo >= x.DateFrom && dateTo <= x.DateTo) ||       
        (dateFrom <= x.DateFrom && dateTo >= x.DateTo)        
            );
        res = !overlappingReservations;

        return res;
    }
}