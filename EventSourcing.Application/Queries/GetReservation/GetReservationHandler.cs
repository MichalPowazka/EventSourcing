using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Queries.GetReservation
{
    public class GetReservationHandler(IReseravtionService reservationRepository, IRoomRepository roomRepository) : IRequestHandler<GetReservationRequest, GetReservationResposne>
    {
        private readonly IReseravtionService _reservationService = reservationRepository; 
        private readonly IRoomRepository _roomRepository = roomRepository;

        //zwracal liste rezerwacji
        // do rezerwacji dociągnąc dane z pokoju
        // stowrzyc  klase ReservationDto ktora bedzie zawiera te rzeczy ktore na froncie
        public async  Task<GetReservationResposne> Handle(GetReservationRequest request, CancellationToken cancellationToken)
        {

            var room = await _roomRepository.GetAsync(request.RoomId);
            var reservations = await _reservationService.GetReservationsForRoom(room.RoomStream);

       
            return new GetReservationResposne()
            {
                Reservations = reservations
            };

        }
    }
} 
