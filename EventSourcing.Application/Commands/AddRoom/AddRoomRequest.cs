using MediatR;

namespace EventSourcing.Application.Commands.AddRoom;

public class AddRoomRequest : IRequest<AddRoomResponse>   
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required string HouseNumber { get; set; }
    public required string ApartamentNumber { get; set; }
    public required string PostCode { get; set; }
}
