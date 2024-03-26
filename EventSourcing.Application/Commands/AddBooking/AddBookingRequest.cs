using MediatR;

namespace EventSourcing.Application.Commands.AddBooking;

public class AddBookingRequest : IRequest<AddBookingResponse>
{
    public string RoomStreamId { get; set; }
    public int RoomId { get; set; }
    public int Id { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int ResevationCount { get; set; }
    public string ControlValue { get; set; }

}
