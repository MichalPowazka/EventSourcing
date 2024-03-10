using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateReservation;

public class UpdateReservationHandler(IReservationRepository _reservationRepository) : IRequestHandler<UpdateReservationRequest, int>
{
    public async Task<int> Handle(UpdateReservationRequest request, CancellationToken cancellationToken)
    {
        var @event = new ReservationEvent()
        {
            Id = request.Id,
            Type = ReseravatioEventType.Update,
            UpdateData = new UpdateReservationEvent()
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo,
            }

        };

        await _reservationRepository.Save(@event);

        return request.Id;
    }
}
