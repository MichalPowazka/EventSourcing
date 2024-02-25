using MediatR;

namespace EventSourcing.Application.Commands.UpdateRoom;

public class UpdateRoomRequest :IRequest<UpdateRoomResponse>
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required string HouseNumber { get; set; }
    public required string ApartamentNumber { get; set; }
    public required string PostCode { get; set; }
}
