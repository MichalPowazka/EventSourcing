using EventSourcing.Application.Commands.AddRoom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class RoomController(IMediator _mediator) : ControllerBase
    {
        //Post do dodaniwa pokoju + command do obslugi
        //Put do update pokoju + command do opslugi
        //Get do pobrania pokoju po id + querry do pobrania
        //Get do listy pokojów + querry do pobrania
        [HttpPost("AddRoom")]
        public ActionResult AddRoom([FromBody] AddRoomRequest request)
        {
            var result = _mediator.Send(request);
            return Ok(result);
        }



    }

}