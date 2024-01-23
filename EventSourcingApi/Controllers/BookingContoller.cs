using EventSourcing.Application.Commands.AddBooking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class BookingContoller(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> AddBooking(AddBookingRequest request)
        {
            var res = await mediator.Send(request);

          
            return Ok(res);
        }
    }
}
