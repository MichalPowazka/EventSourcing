using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Queries.GetUserHistory;

public class GetUserHistoryHandler(UserManager<User> _userManager, IUserEventsRepository _userEventsRepository) : IRequestHandler<GetUserHistoryQueryRequest, GetUserHistoryResponse>
{
    public async Task<GetUserHistoryResponse> Handle(GetUserHistoryQueryRequest request, CancellationToken cancellationToken)
    {

        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        var events = await _userEventsRepository.GetById(user.StreamId).ToListAsync();


        var result = events.Select(x => new UserHistoryDto
        {
            DateTime = x.Date,
            Type = x.Type.ToString(),
            UserNakme = x.User.UserName

        }).ToList();
        return new GetUserHistoryResponse() { History = result };

    }
}
