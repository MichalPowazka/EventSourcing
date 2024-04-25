using EventSourcing.Application.Commands.DisactiveUser;
using EventSourcing.Application.Commands.Login;
using EventSourcing.Application.Commands.Register;
using EventSourcing.Application.Commands.RestorePassword;
using EventSourcing.Application.Commands.UpdateUser;
using EventSourcing.Application.Queries.GetUserHistory;
using EventSourcingApi.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AccountController(IMediator _mediator) : Controller
{

    [HttpPost]
    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPost]
    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPost]
    [RoleAuthorize("User")]
    public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPost]
    [RoleAuthorize("User")]
    public async Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }
    [HttpPost]
    [RoleAuthorize("Admin")]
    public async Task<ChangeStatusUserResponse> ChangeStatusUser(ChangeStatusUserRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpGet]
    [RoleAuthorize("Admin")]
    public async Task<GetUserHistoryResponse> GetUserHistory([FromQuery]GetUserHistoryQueryRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

}
