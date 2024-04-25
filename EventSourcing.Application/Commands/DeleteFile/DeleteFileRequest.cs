using MediatR;

namespace EventSourcing.Application.Commands.DeleteFile
{
    public class DeleteFileRequest: IRequest<DeleteFileResponse>
    {
        public int Id { get; set; }
    }
}
