﻿using EventSourcing.Application.Services;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateReservation;

public class UpdateReservationHandler(IAggreagte<ReservationEvent> _reservationRepository, IReseravtionService _reseravtionService, IUserContext _userContext) : IRequestHandler<UpdateReservationRequest, UpdateReservationResponse>
{
    public async Task<UpdateReservationResponse> Handle(UpdateReservationRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var isAvaible = await _reseravtionService.IsAvaible(request.RoomId, request.DateFrom, request.DateTo);
            if(!isAvaible)
            {
                return new UpdateReservationResponse()
                {
                    IsSuccess = false,
                    Message = "Pokój niedostępny"
                };
            }
            var @event = new ReservationEvent()
            {
                Id = request.Id,
                ReservationUniqueid = request.ReservationUniqueId,
                RoomStream = request.RoomStreamId,
                Type = ReseravatioEventType.Update,
                UpdateData = new UpdateReservationEvent()
                {
                    DateFrom = request.DateFrom,
                    DateTo = request.DateTo,
                    User = await _userContext.GetCurrentUser()
                }

            };

            await _reservationRepository.Save(@event);

            return new UpdateReservationResponse()
            {
                IsSuccess = true,
                Message = "Aktualizacja powiodła się",
            };

        }
        catch(Exception ex)
        {
            return new UpdateReservationResponse()
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
        
    }
}
