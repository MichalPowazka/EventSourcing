using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Commands.DisactiveUser;

public class ChangeStatusUserHandler(UserManager<User> _userManager, IAggreagte<UserEvent> _userEventsRepository) : IRequestHandler<ChangeStatusUserRequest, ChangeStatusUserResponse>
{
    public async Task<ChangeStatusUserResponse> Handle(ChangeStatusUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            return new ChangeStatusUserResponse()
            {
                IsSuccess = false,
                Message = "Brak użytkownika"
            };
        }
        user.IsActive = !user.IsActive;
        var updtateResult = await _userManager.UpdateAsync(user);
        if (updtateResult.Succeeded)
        {
            var @event = new UserEvent()
            {
                UniqueId = user.StreamId,
                Date = DateTime.UtcNow,
                User = user,
                Type = UserEventType.SuccessChangeStatus
            };
            await _userEventsRepository.Save(@event);
            return new ChangeStatusUserResponse()
            {
                IsSuccess = true,
                Message = "Zmiana statusu użytkownika powiodła się"
            };
        }
        else
        {

            var @event = new UserEvent()
            {
                UniqueId = user.StreamId,
                Date = DateTime.UtcNow,
                User = user,
                Type = UserEventType.FailedChangeStatus
            };
            await _userEventsRepository.Save(@event);
            return new ChangeStatusUserResponse()
            {
                IsSuccess = false,
                Message = "Coś poszlo nie tak"
            };
        }
       
    }
}
