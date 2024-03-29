﻿using EventSourcing.Application.Commands.UpdateRoom;
using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Domain.Events.Users;
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
    public class UpdateUserHandler(UserManager<User> _userManager, IUserEventsRepository _userEventsRepository) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
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

            //ZApis eventu do event store

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

                return new UpdateUserResponse { Success = true };
            }
            else
            {
                var @event = new UserEvent()
                {
                    UniqueId = user.StreamId,
                    Date = DateTime.UtcNow,
                    User = user,
                    Type = UserEventType.FailedLogin
                };
                await _userEventsRepository.Save(@event);
                // Obsłuż błąd gdy nie udało się zaktualizować użytkownika
                return new UpdateUserResponse { Success = false, Message = "Nie udało się zaktualizować użytkownika." };
            }


        }


    }
}
