using MediatR;

namespace EventSourcing.Application.Commands.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
