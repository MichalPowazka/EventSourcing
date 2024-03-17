﻿using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.CancelReservation
{

    public class CancelReservationHandler(IReservationRepository _reservationRepository) : IRequestHandler<CancelReservationRequest, int>
    {
        public async Task<int> Handle(CancelReservationRequest request, CancellationToken cancellationToken)
        {
            var @event = new ReservationEvent()
            {
                Reservation = new Guid(request.Id),
                Type = ReseravatioEventType.Cancel,
                CancelData = new CancelReservationEvent()
                {
                    CancelReason = request.ResolveDescription

                }
            };

            await _reservationRepository.Save(@event);

            return -1;
        }
    }

}
