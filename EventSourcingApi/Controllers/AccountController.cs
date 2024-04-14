using EventSourcing.Application.Commands.Login;
using EventSourcing.Application.Commands.Register;
using EventSourcing.Application.Commands.RestorePassword;
using EventSourcing.Application.Commands.UpdateUser;
using EventSourcing.Application.Queries.GetUserHistory;
using EventSourcingApi.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController(IMediator _mediator) : Controller
    {
        //upadteUsera
        //zmiana hasla
        //usuwamoe konta ---- do zrobienia
        //logowanie = jwt zaimplemenotwac ---- do zrobienia


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
        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPost]
        public async Task<ResotrePasswordResponse> RestorePassword(RestorePasswordRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        [RoleAuthorize("Admin")]
        public async Task<GetUserHistoryResponse> GetUserHistory([FromQuery] GetUserHistoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }
    }
}
