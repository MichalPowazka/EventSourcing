using MediatR;

namespace EventSourcing.Application.Commands.Register
{
    public class RegisterRequest : IRequest<RegisterResponse>
    {
        public string FirstName {  get; set; }
        public string LastName {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
