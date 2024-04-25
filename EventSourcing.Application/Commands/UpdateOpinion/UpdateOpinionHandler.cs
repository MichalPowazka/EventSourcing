using EventSourcing.Application.Services;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UpdateOpinion;

public class UpdateOpinionHandler(IOpinionRepository opinionRepository,  IUserContext userContext) : IRequestHandler<UpdateOpinionRequest, UpdateOpinionResponse>
{
    public async Task<UpdateOpinionResponse> Handle(UpdateOpinionRequest request, CancellationToken cancellationToken)
    {
        var existingOpinion = await opinionRepository.GetAsync(request.Id);
        if (existingOpinion == null)
        {
            return new UpdateOpinionResponse()
            {
                IsSuccess = false,
                Message = "Taka opinia nie istnieje"
            };
        }

        if (existingOpinion.User != null)
        {
            if (existingOpinion.User.Id == (await userContext.GetCurrentUser()).Id)
            {
                existingOpinion.Rating = request.Rating;
                existingOpinion.Text = request.Text;
                await opinionRepository.UpdateAsync(existingOpinion);
            }
            else
            {
                return new UpdateOpinionResponse()
                {
                    IsSuccess = false,
                    Message = "To nie twoja opinia"
                };
            }
        }else
        {
            return new UpdateOpinionResponse()
            {
                IsSuccess = false,
                Message = "To nie twoja opinia"
            };
        }


        return new UpdateOpinionResponse()
        {
            IsSuccess = true,
            Message = "Zmiana oceny powiodła się"
        };
    }
}
