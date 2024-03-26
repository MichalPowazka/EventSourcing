using EventSourcing.Application.Commands.UpdateReservation;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventSourcing.Application.Commands.CancelReservation
{

    public class CancelReservationHandler(IReservationRepository _reservationRepository) : IRequestHandler<CancelReservationRequest, CancelReservationResponse>
    {
        public async Task<CancelReservationResponse> Handle(CancelReservationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var @event = new ReservationEvent()
                {
                    RoomStream = request.RoomStreamId,
                    ReservationUniqueid = request.ReservationUniqueId,
                    Type = ReseravatioEventType.Cancel,
                    CancelData = new CancelReservationEvent()
                    {
                        CancelReason = request.ResolveDescription

                    }
                };

                await _reservationRepository.Save(@event);

                return new CancelReservationResponse()
                {
                    IsSuccess = true,
                    Message = "Anulowanie powiodło się",
                };
            }
            catch (Exception ex)
            {
                return new CancelReservationResponse()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
           
        }
    }

}
