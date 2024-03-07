using EventSourcing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.RestorePassword
{
    public class RestorePasswordHandler(UserManager<User> _userManager) : IRequestHandler<RestorePasswordRequest, ResotrePasswordResponse>
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
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
                if (!result.Succeeded)
                {
                    // Obsłuż błąd gdy nie udało się zaktualizować hasła
                    return new ResotrePasswordResponse { Success = false, Message = "Nie udało się zaktualizować hasła użytkownika." };
                }
            }

            // Jeśli chcesz zaimplementować także aktualizację innych danych użytkownika, możesz to zrobić tutaj

            return new ResotrePasswordResponse { Success = true };
        }



    }
    
}
