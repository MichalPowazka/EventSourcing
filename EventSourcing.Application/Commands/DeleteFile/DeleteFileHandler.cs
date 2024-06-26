﻿using EventSourcing.Persistance.Repositories;
using MediatR;

namespace EventSourcing.Application.Commands.DeleteFile
{
    public class DeleteFileHandler(IRoomRepository _roomRepository) : IRequestHandler<DeleteFileRequest, DeleteFileResponse>
    {
        public async Task<DeleteFileResponse> Handle(DeleteFileRequest request, CancellationToken cancellationToken)
        {
            var image = await _roomRepository.GetImageAsync(request.Id);
            if (image != null)
            {
                await _roomRepository.DeleteImage(image);
                return new DeleteFileResponse()
                {
                    IsSuccess = true,
                    Message = "Usuniecie powiodło się"
                };
            }

            return new DeleteFileResponse()
            {
                IsSuccess = false,
                Message = "Nie powiodło się"
            };
        }
    }
}
