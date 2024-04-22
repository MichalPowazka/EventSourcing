using MediatR;

namespace EventSourcing.Application.Commands.DisactiveUser;

public class ChangeStatusUserRequest : IRequest<ChangeStatusUserResponse>
{
    public int Id { get; set; }
}
