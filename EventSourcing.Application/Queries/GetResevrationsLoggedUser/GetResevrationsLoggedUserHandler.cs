using EventSourcing.Application.Dto;
using EventSourcing.Application.Queries.GetReservationsAll;
using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Queries.GetResevrationsLoggedUser
{
    public class GetResevrationsLoggedUserHandler(IReseravtionService _reservationService, IRoomRepository _roomRepository, IUserContext _userContext) : IRequestHandler<GetResevrationsLoggedUserQueryRequest, GetResevrationsLoggedUserResponse>
    {
        public async Task<GetResevrationsLoggedUserResponse> Handle(GetResevrationsLoggedUserQueryRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var myReservations = new List<ReservationDto>();
            var currentUser = await _userContext.GetCurrentUser();

            foreach (var room in rooms)
            {
                var reservations = await _reservationService.GetReservationsForRoom(room.RoomStream);
                reservations = reservations.Where(r => r.User !=null && r.User.Id == currentUser.Id).ToList();
                myReservations.AddRange(reservations);
            }

            return new GetResevrationsLoggedUserResponse()
            {
                Reservations = myReservations
            };
        }
    }
}
