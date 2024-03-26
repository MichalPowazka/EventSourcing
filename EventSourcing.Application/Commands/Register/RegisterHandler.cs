using EventSourcing.Domain.Entities;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Commands.Register
{
    public class RegisterHandler(UserManager<User> _userManager, IUserEventsRepository _userEventsRepository) : IRequestHandler<RegisterRequest, RegisterResponse>
    {
        public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            //_userManager.CreateAsync()
            var user = new User
            {

                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                StreamId = Guid.NewGuid().ToString()

            };

            try
            {



                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var @event = new UserEvent()
                    {
                        UniqueId = user.StreamId,
                        Date = DateTime.UtcNow,
                        User = user,
                        Type = UserEventType.Register
                    };
                    await _userEventsRepository.Save(@event);
                }
                await _userManager.AddToRoleAsync(user, "User");

            }
            catch (Exception ex)
            {
                var a = ex;
            }




            return new RegisterResponse();
        }
    }
}
