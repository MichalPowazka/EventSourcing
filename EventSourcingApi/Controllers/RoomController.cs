using EventSourcing.Application.Commands.AddRoom;
using EventSourcing.Application.Commands.UpdateRoom;
using EventSourcing.Application.Queries.GetRoomAll;
using EventSourcing.Application.Queries.GetRoomById;
using EventSourcing.Application.Commands.UploadFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EventSourcingApi.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]

    public class RoomController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("add-room")]

        public async Task<ActionResult> AddRoom([FromBody] AddRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("update-room")]
        public async Task<ActionResult> UpdateRoom([FromBody] UpdateRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("get-room")]

        public async Task<ActionResult> GetRoomById([FromQuery] GetRoomByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("get-room-all")]
        [Authorize]
        public async Task<ActionResult> GetRoomAll([FromQuery] GetRoomAllQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost("upload-file")]
        public async Task<ActionResult> UploadFile(UploadFileRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }





    }

}