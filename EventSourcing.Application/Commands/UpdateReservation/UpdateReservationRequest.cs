using MediatR;

namespace EventSourcing.Application.Commands.UpdateReservation
{
    public class UpdateReservationRequest : IRequest<int>
    {
        public int Id {  get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }    
    }
}
