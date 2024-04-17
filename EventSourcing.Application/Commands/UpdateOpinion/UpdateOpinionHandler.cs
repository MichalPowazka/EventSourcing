using EventSourcing.Application.Commands.AddOpinion;
using EventSourcing.Application.Services;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UpdateOpinion
{
    public class UpdateOpinionHandler(IOpinionRepository opinionRepository, IRoomRepository roomRepository, IUserContext userContext) : IRequestHandler<UpdateOpinionRequest, UpdateOpinionResponse>
    {
        public async Task<UpdateOpinionResponse> Handle(UpdateOpinionRequest request, CancellationToken cancellationToken)
        {
            var existingOpinion = await opinionRepository.GetAsync(request.Id);
            existingOpinion.Rating = request.Rating;
            existingOpinion.Text = request.Text;

            if(existingOpinion == null) 
            {
                return new UpdateOpinionResponse() 
                {
                    IsSuccess = false,
                    Message = "Taka opinia nie istnieje"
                };
            }

            await opinionRepository.UpdateAsync(existingOpinion);

            return new UpdateOpinionResponse()
            {
                IsSuccess = true,
                Message = "Zmiana oceny powiodła się"
            };
        }
    }
}
