using EventSourcing.Application.Commands.UpdateRoom;
using EventSourcing.Domain.Entities;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Commands.UpdateUser
{
    public class UpdateUserHandler(UserManager<User> _userManager, RoleManager<Role> _roleManager) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
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

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;

            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return new UpdateUserResponse { Success = true };
            }
            else
            {
                // Obsłuż błąd gdy nie udało się zaktualizować użytkownika
                return new UpdateUserResponse { Success = false, Message = "Nie udało się zaktualizować użytkownika." };
            }

            
        }


    }
}
