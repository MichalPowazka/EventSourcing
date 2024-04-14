using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UploadFile
{
    public class UploadFileRequest :IRequest<UploadFileResponse>
    {
        public int RoomId { get; set; }
        public IFormFile File {  get; set; }
    }
}
