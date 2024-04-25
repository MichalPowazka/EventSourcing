using EventSourcing.Application.Commands.AddOpinion;
using EventSourcing.Application.Commands.UpdateOpinion;
using EventSourcingApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class OpinionController(IMediator _mediator) : Controller
{
    [HttpPost]
    [RoleAuthorize("User")]
    public async Task<AddOpinionResponse> AddOpinion(AddOpinionRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPost]
    [RoleAuthorize("User")]
    public async Task<UpdateOpinionResponse> UpdateOpinion(UpdateOpinionRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }
}
