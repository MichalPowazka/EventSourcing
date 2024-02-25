using EventSourcing.Application.Commands.Login;
using EventSourcing.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController(IMediator _mediator) : Controller
    {

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest request)
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterRequest request)
        {
            var result = _mediator.Send(request);
            return Ok();
        }
    }
}
