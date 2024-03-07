using EventSourcing.Application.Commands.Login;
using EventSourcing.Application.Commands.Register;
using EventSourcing.Application.Commands.RestorePassword;
using EventSourcing.Application.Commands.UpdateUser;
using MediatR;
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
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        
        public async Task<ActionResult> UpdateUser(UpdateUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<ActionResult> RestorePassword(RestorePasswordRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok();
        }
    }
}
