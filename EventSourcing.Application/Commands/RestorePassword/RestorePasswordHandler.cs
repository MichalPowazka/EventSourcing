using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.RestorePassword
{
    public class RestorePasswordHandler(UserManager<User> _userManager, IUserEventsRepository _userEventsRepository) : IRequestHandler<RestorePasswordRequest, ResotrePasswordResponse>
    {
        public async Task<ResotrePasswordResponse> Handle(RestorePasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                // Obsłuż błąd gdy użytkownik nie istnieje

                return new ResotrePasswordResponse { Success = false, Message = "Użytkownik nie istnieje." };
            }

         

            // Zaktualizuj hasło użytkownika
            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                var result = await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
                //var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                //var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
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
                    // Obsłuż błąd gdy nie udało się zaktualizować hasła
                    return new ResotrePasswordResponse { Success = false, Message = "Nie udało się zaktualizować hasła użytkownika." };
                }
                else
                {
                    //ZApis eventu do event store
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

            // Jeśli chcesz zaimplementować także aktualizację innych danych użytkownika, możesz to zrobić tutaj

            return new ResotrePasswordResponse { Success = true };
        }



    }

}
