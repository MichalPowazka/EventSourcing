using EventSourcing.Application.Services;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.CancelReservation
{

    public class CancelReservationHandler(IAggreagte<ReservationEvent> _reservationRepository, IUserContext _userContext) : IRequestHandler<CancelReservationRequest, CancelReservationResponse>
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
                        CancelReason = request.ResolveDescription,
                        User = await _userContext.GetCurrentUser(),

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
