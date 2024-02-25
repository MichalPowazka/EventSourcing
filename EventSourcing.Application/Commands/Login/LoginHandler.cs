using MediatR;

namespace EventSourcing.Application.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
