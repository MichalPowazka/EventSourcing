using EventSourcing.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EventSourcing.Application.Commands.Register
{
    public class RegisterHandler(UserManager<User> _userManager) : IRequestHandler<RegisterRequest, RegisterResponse>
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
                //if (!await _roleMenager.RoleExistsAsync("User"))
                //{
                //    await _roleMenager.CreateAsync(new Role() { Name = "User" });
                //}

                //ZApis eventu do event store


                var result = await _userManager.CreateAsync(user, request.Password);

            }
            catch (Exception ex)
            {
                var a = ex;
            }




            return new RegisterResponse();
        }
    }
}
