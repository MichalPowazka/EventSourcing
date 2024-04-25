using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Queries.GetRoomAll;

public class GetRoomAllHandler(IRoomRepository _roomRepository, IUserContext _userContext) : IRequestHandler<GetRoomAllQueryRequest, GetRoomAllResponse>
{
    public async Task<GetRoomAllResponse> Handle(GetRoomAllQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await _roomRepository.GetAllAsync();
        if (result == null)
        {
            return new GetRoomAllResponse()
            {

                IsSuccess = false,
            };
        }

        var isAdmin = (await _userContext.GetCurrentUserRoles()).Any(x => x == "Admin");

        if (!isAdmin)
        {
            result = result.Where(x => x.IsActive).ToList();
        }

        foreach (var room in result)
        {
            foreach (var image in room.Images)
            {
                Byte[] bytes = File.ReadAllBytes(image.ImagePath);
                var imageBase64 = Convert.ToBase64String(bytes);
                image.Image = imageBase64;
            }
        }


        return new GetRoomAllResponse()
        {
               ListRooms = [.. result],
               IsSuccess = true   
        };
    }
}
