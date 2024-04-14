using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.UploadFile
{
    public class UploadFileHandler(IRoomRepository _roomRepository) : IRequestHandler<UploadFileRequest, UploadFileResponse>
    {
        public async Task<UploadFileResponse> Handle(UploadFileRequest request, CancellationToken cancellationToken)
        {

            if (request.File != null && request.File.Length > 0)
            {
                var filePath = Path.Combine(@"D:\", request.File.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.File.CopyToAsync(fileStream);
                }
                var roomImage = new RoomImage()
                {
                    RoomId = request.RoomId,
                    ImagePath = filePath,
                    Name = request.File.FileName
                };
                var a = await _roomRepository.AddImageAsync(roomImage);

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
