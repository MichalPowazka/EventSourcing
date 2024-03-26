using MediatR;

namespace EventSourcing.Application.Commands.UpdateReservation
{
    public class UpdateReservationRequest : IRequest<UpdateReservationResponse>
    {
        public string ReservationUniqueId { get; set; }
        public string RoomStreamId { get; set; }
        public int RoomId { get; set; }

        public int Id {  get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }    
    }
}
