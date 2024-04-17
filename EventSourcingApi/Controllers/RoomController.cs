using EventSourcing.Application.Commands.AddRoom;
using EventSourcing.Application.Commands.UpdateRoom;
using EventSourcing.Application.Queries.GetRoomAll;
using EventSourcing.Application.Queries.GetRoomById;
using EventSourcing.Application.Commands.UploadFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventSourcing.Application.Commands.DeleteFile;
using EventSourcingApi.Common;

namespace EventSourcingApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class RoomController(IMediator _mediator, IHttpContextAccessor _httpContextAccessor) : Controller
    {

        [HttpPost]
        [RoleAuthorize("Admin")]

        public async Task<AddRoomResponse> AddRoom(AddRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpPut]
        [RoleAuthorize("Admin")]

        public async Task<UpdateRoomResponse> UpdateRoom(UpdateRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<GetRoomByIdResponse> GetRoomById([FromQuery] GetRoomByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet]
        public async Task<GetRoomAllResponse> GetRoomAll([FromQuery] GetRoomAllQueryRequest request)
        {

            var result = await _mediator.Send(request);
            return result;
        }


        [HttpPost]
        [RoleAuthorize("Admin")]

        public async Task<UploadFileResponse> UploadFile(UploadFileRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete]
        [RoleAuthorize("Admin")]

        public async Task<DeleteFileResponse> DeleteFile(DeleteFileRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }



    }

}