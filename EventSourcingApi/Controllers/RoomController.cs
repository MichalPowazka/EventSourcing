using EventSourcing.Application.Commands.AddRoom;
using EventSourcing.Application.Commands.UpdateRoom;
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
        //Upload Zdjec do pokoju
        [HttpPost("add-room")]
        public async Task<ActionResult> AddRoom([FromBody] AddRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("update-room")]
        public async Task<ActionResult> UpdateRoom([FromBody] UpdateRoomRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }


        [HttpPost("upload-file")]
        public async Task<ActionResult> UploadFile(IFormFile form)
        {
            var a = form;
            string filePath = Path.Combine(@"D:\", form.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await form.CopyToAsync(fileStream);
            }
                return Ok();
        }





    }

}