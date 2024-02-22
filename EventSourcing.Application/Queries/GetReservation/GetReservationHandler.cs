using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Queries.GetReservation
{
    public class GetReservationHandler : IRequestHandler<GetReservationRequest, GetReservationResposne>
    {
        private readonly IReservationRepository _reservationRepository; 
        private readonly IRoomRepository _roomRepository;   

        public GetReservationHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        //zwracal liste rezerwacji
        // do rezerwacji dociągnąc dane z pokoju
        // stowrzyc  klase ReservationDto ktora bedzie zawiera te rzeczy ktore na froncie
        public async  Task<GetReservationResposne> Handle(GetReservationRequest request, CancellationToken cancellationToken)
        {
            //pobieranie obiektu z bazydanych podstawiach dociągając powiązania pomiedzy pokojem a rezerwacjami
            //pozniej w pętli pobrac wszytkie rezerwacjie  dla tego pokoju z event store
            //zwrocic odpwiednio liste  obiektów do api
            //Reservation jest z eventstore
            //W Db do ktoreggo pokoju ktore rezerwacje

            var room = await _roomRepository.GetAsync(request.RoomId);
            foreach(var reservation in room.Reservations)
            {
               var res =  _reservationRepository.GetById(reservation.StreamId);
            }

            return new GetReservationResposne();

        }
    }
}
