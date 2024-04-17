using EventSourcing.Application.Commands.AddOpinion;
using EventSourcing.Application.Commands.AddRoom;
using EventSourcing.Application.Commands.UpdateOpinion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OpinionController(IMediator _mediator) : Controller
    {
        [HttpPost]
        public async Task<AddOpinionResponse> AddOpinion(AddOpinionRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        public async Task<UpdateOpinionResponse> UpdateOpinion(UpdateOpinionRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
