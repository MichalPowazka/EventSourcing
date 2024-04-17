using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.AddOpinion
{
    public class AddOpinionHandler(IOpinionRepository opinionRepository,IRoomRepository roomRepository, IUserContext userContext) : IRequestHandler<AddOpinionRequest, AddOpinionResponse>
    {
        public async Task<AddOpinionResponse> Handle(AddOpinionRequest request, CancellationToken cancellationToken)
        {
            var room = await roomRepository.GetAsync(request.RoomId);
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
}
