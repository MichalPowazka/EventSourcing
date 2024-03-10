using EventSourcing.Domain.Events;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventSourcing.Application.Commands.AddBooking
{
    public class AddBookingHandler(IReservationRepository _reservationRepository, IRoomRepository _roomRepository) : IRequestHandler<AddBookingRequest, int>
    {
        public async Task<int> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            //
            //powiaznie rezerwacji z pokojem


            var @event = new ReservationEvent()
            {
                Id = request.Id,
                Reservation = Guid.NewGuid(),
                Type  = ReseravatioEventType.Create, 
                CreateData = new CreateReservationEvenet()
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                },
             
            };

            //powiaznie rezerwacji z pokojem
            await _roomRepository.BookingRoom(new Domain.Entities.RoomToReservation()
            {
                RoomId = request.RoomId,
                StreamId = @event.Reservation.ToString(),
            });

            await _reservationRepository.Save(@event);

            return request.Id;



            //booking.add
        }
    }
}
