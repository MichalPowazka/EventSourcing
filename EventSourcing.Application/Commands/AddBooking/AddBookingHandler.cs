using EventSourcing.Application.Services;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddBooking
{
    public class AddBookingHandler(IRoomRepository _roomRepository, IReseravtionService _reseravtionService) : IRequestHandler<AddBookingRequest, AddBookingResponse>
    {
        public async Task<AddBookingResponse> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {

                var isAvaible = await _reseravtionService.IsAvaible(request.RoomId, request.DateFrom, request.DateTo);
                if (!isAvaible)
                {
                    return new AddBookingResponse()
                    {
                        IsSuccess = false,
                        Message = "Pokój niedostępny"
                    };

                }
                var room = await _roomRepository.GetAsync(request.RoomId);
                if (request.ControlValue != room.ControlValue)
                {
                    isAvaible = await _reseravtionService.IsAvaible(request.RoomId, request.DateFrom, request.DateTo);
                    if (isAvaible)
                    {
                        var res = await _reseravtionService.AddReservation(request, room);
                        if (!res)
                        {
                            return new AddBookingResponse()
                            {
                                IsSuccess = false,
                                Message = "Odśwież stronę"
                            };
                        }
                    }
                    else
                    {
                    return new AddBookingResponse()
                    {
                        IsSuccess = false,
                        Message = "Pokój niedostępny"
                    };
                }
                }
                else
                {
                    var res = await _reseravtionService.AddReservation(request, room);
                    if (!res)
                    {
                    return new AddBookingResponse()
                    {
                        IsSuccess = false,
                        Message = "Coś poszło nie tak . . ."
                    };
                }

                }

            await _reseravtionService.GetReservationsForRoom(request.RoomStreamId);




            return new AddBookingResponse()
            {
                IsSuccess = true,
            };

        }
    }
}
