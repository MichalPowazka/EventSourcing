using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Queries.GetUserHistory;

public class GetUserHistoryHandler(UserManager<User> _userManager, IAggreagte<UserEvent> _userEventsRepository) : IRequestHandler<GetUserHistoryQueryRequest, GetUserHistoryResponse>
{
    public async Task<GetUserHistoryResponse> Handle(GetUserHistoryQueryRequest request, CancellationToken cancellationToken)
    {

        var user = await _userManager.FindByIdAsync(request.Id.ToString());

        if (user == null)
        {
            return new GetUserHistoryResponse()
            {
                IsSuccess = false,
                Message= "Użytkownik o takim ID nie istnieje"
            };
;
        }
        var events = await _userEventsRepository.GetById(user.StreamId).ToListAsync(cancellationToken: cancellationToken);


        var result = events.Select(x => new UserHistoryDto
        {
            DateTime = x.Date,
            Type = x.Type.ToString(),
            UserNakme = x.User.UserName

        }).ToList();
        return new GetUserHistoryResponse() { History = result, IsSuccess= true };

    }
}
