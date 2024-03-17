using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddBooking
{
    public class AddBookingHandler(IReservationRepository _reservationRepository, IRoomRepository _roomRepository, IReseravtionService _reseravtionService) : IRequestHandler<AddBookingRequest, int>
    {
        public async Task<int> Handle(AddBookingRequest request, CancellationToken cancellationToken)
        {
            //
            //powiaznie rezerwacji z pokojem
            // pobiieramy pokok
            var isAvaible = await _reseravtionService.IsAvaible(request.RoomId, request.DateFrom, request.DateTo);
            if (!isAvaible)
            {
                //rzucasz wyjatątek
                return -1;

            }
            var room = await _roomRepository.GetAsync(request.RoomId);
            if (request.ControlValue != room.ControlValue || room.Reservations.Count != request.ResevationCount) 
            {
                isAvaible = await _reseravtionService.IsAvaible(request.RoomId, request.DateFrom, request.DateTo);
                if (isAvaible)
                {
                    var res =  await _reseravtionService.AddReservation(request, room);
                    if (!res)
                    {
                        //cos poszlo nie tak
                    }
                }
                else
                {
                    //obsluzyc niedostspneosc
                }
            }
            else
            {
                var res = await _reseravtionService.AddReservation(request, room);
                if (!res)
                {
                    //cos poszlo nie tak
                }

            }

            //tranzacje



            return request.Id;



            //booking.add
        }
    }
}
