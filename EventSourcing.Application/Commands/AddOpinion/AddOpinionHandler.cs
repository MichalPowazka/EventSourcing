using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.AddOpinion;

public class AddOpinionHandler(IOpinionRepository opinionRepository, IUserContext userContext) : IRequestHandler<AddOpinionRequest, AddOpinionResponse>
{
    public async Task<AddOpinionResponse> Handle(AddOpinionRequest request, CancellationToken cancellationToken)
    {
        var opinion = new Opinion()
        {
            Rating = request.Rating,
            Text = request.Text,
            User = await userContext.GetCurrentUser(),
            RoomId = request.RoomId,
        };

        await opinionRepository.AddAsync(opinion);

        return new AddOpinionResponse();
    }
}
