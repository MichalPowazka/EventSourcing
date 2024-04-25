using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Commands.UpdateUser
{
    public class UpdateUserHandler(UserManager<User> _userManager, IAggreagte<UserEvent> _userEventsRepository) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {

                return new UpdateUserResponse()
                {
                    Success = false,
                    Message = "Użytkownik nie istnieje."
                };
            }
            if (string.IsNullOrEmpty(user.StreamId))
            {
                user.StreamId = Guid.NewGuid().ToString();  
            }
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            var updateResult = await _userManager.UpdateAsync(user);


            if (updateResult.Succeeded)
            {
                var @event = new UserEvent()
                {
                    UniqueId = user.StreamId,
                    Date = DateTime.UtcNow,
                    User = user,
                    Type = UserEventType.SuccessChangeData
                };
                await _userEventsRepository.Save(@event);

                return new UpdateUserResponse { Success = true , Message = "Aktualizacja powiodła się." };
            }
            else
            {
                var @event = new UserEvent()
                {
                    UniqueId = user.StreamId,
                    Date = DateTime.UtcNow,
                    User = user,
                    Type = UserEventType.FailedChangeData
                };
                await _userEventsRepository.Save(@event);
                return new UpdateUserResponse { Success = false, Message = "Nie udało się zaktualizować użytkownika." };
            }


        }


    }
}
