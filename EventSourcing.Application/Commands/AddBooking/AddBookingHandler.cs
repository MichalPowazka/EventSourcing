using EventSourcing.Domain.Events;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddBooking
{
    public class AddBookingHandler(IReservationRepository _reservationRepository, IRoomRepository _roomRepository) : IRequestHandler<AddBookingRequest, int>
    {
        public async Task<int> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            //
            //powiaznie rezerwacji z pokojem


            var @event = new CreateReservationEvenet()
            {
                Id = request.Id,
                Reservation = Guid.NewGuid(),
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
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
