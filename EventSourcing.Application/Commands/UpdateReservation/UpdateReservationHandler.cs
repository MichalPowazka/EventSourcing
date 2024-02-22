using EventSourcing.Domain.Events;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UpdateReservation
{
    public class UpdateReservationHandler(IReservationRepository _reservationRepository) : IRequestHandler<UpdateReservationRequest, int>
    {
        public async Task<int> Handle(UpdateReservationRequest request, CancellationToken cancellationToken)
        {
            var @event = new UpdateReservationEvent()
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
