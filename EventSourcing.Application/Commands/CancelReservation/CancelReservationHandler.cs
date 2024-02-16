using EventSourcing.Domain.Events;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.CancelReservation
{

    public class CancelReservationHandler(IReservationRepository _reservationRepository) : IRequestHandler<CancelReservationRequest, int>
    {
        public async Task<int> Handle(CancelReservationRequest request, CancellationToken cancellationToken)
        {
            var @event = new CancelReservationEvent()
            {
                Id = request.Id,
                CancelReason = request.ResolveDescription
            };

           await _reservationRepository.Save(@event);

            return -1;
        }
    }

}
