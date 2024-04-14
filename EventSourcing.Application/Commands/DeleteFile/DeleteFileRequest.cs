using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.DeleteFile
{
    public class DeleteFileRequest: IRequest<DeleteFileResponse>
    {
        public int Id { get; set; }
    }
}
