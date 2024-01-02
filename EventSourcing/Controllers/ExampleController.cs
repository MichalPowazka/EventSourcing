using EventSourcing.Application.Queries.GetExampleModelById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        public readonly IMediator _mediator;

        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GetAsync([FromBody] GetExampleModelByIdRequest request)
        {
            var res = await _mediator.Send(request);

            if (res is null) return NoContent();

            return Ok(res);
        }

    }
}
