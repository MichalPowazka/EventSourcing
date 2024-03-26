using EventSourcing.Application.Commands.AddRoom;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UploadFile
{
    public class UploadFileHandler(IRoomRepository _roomRepository) : IRequestHandler<UploadFileRequest, UploadFileResponse>
    {
        async Task<UploadFileResponse> IRequestHandler<UploadFileRequest, UploadFileResponse>.Handle(UploadFileRequest request, CancellationToken cancellationToken)
        {
            
            if (request.File !=null && request.File.Length > 0) 
            {
                var filePath = Path.Combine(@"D:\", request.File.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(fileStream);
                }

                

                return new UploadFileResponse
                {
                    Message = "Success"
                };
            }
            else
            {
                return new UploadFileResponse
                {
                    Message = "Failed"
                };
            }
        }
    }
}
