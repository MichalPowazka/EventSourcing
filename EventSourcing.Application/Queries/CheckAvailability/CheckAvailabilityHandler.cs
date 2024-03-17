using EventSourcing.Application.Services;
using MediatR;

namespace EventSourcing.Application.Queries.CheckAvailability
{
    public class CheckAvailabilityHandler(IReseravtionService _reseravtionService) : IRequestHandler<CheckAvailabilityQueryRequest, CheckAvailabilityResponse>
    {
        public async Task<CheckAvailabilityResponse> Handle(CheckAvailabilityQueryRequest request, CancellationToken cancellationToken)
        {

            return new CheckAvailabilityResponse()
            {
                Available = await _reseravtionService.IsAvaible(request.Id, request.DateFrom, request.DateTo)
            };
        }
    }
}
