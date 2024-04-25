using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Commands.RestorePassword;

public class ChangePasswordHandler(UserManager<User> _userManager, IAggreagte<UserEvent> _userEventsRepository) : IRequestHandler<ChangePasswordRequest, ChangePasswordResponse>
{
    public async Task<ChangePasswordResponse> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
        {
            return new ChangePasswordResponse { Success = false, Message = "Użytkownik nie istnieje." };
        }

   

        if (!string.IsNullOrEmpty(request.NewPassword))
        {
            var result = await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
            if (!result.Succeeded)  
            {

                var @event = new UserEvent()
                {
                    UniqueId = user.StreamId,
                    Date = DateTime.UtcNow,
                    User = user,
                    Type = UserEventType.FailedChangePassword

                };
                await _userEventsRepository.Save(@event);
                return new ChangePasswordResponse { Success = false, Message = "Nie udało się zaktualizować hasła użytkownika." };
            }
            else
            {
                var @event = new UserEvent()
                {
                    UniqueId = user.StreamId,
                    Date = DateTime.UtcNow,
                    User = user,
                    Type = UserEventType.SuccessChangePassword

                };
                await _userEventsRepository.Save(@event);

            }
        }
        return new ChangePasswordResponse { Success = true };
    }



}
