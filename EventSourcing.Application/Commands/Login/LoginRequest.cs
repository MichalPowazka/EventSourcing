using MediatR;

namespace EventSourcing.Application.Commands.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
    }
}
