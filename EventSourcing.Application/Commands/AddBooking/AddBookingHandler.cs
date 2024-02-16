using EventSourcing.Domain.Events;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddBooking
{
    public class AddBookingHandler(IReservationRepository _reservationRepository) : IRequestHandler<AddBookingRequest, int>
    {
        public async Task<int> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            var @event = new CreateReservationEvenet()
            {
                Id = request.Id,
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
            };

            await _reservationRepository.Save(@event);
            
            return request.Id;

            


        }
    }
}
