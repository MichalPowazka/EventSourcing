using MediatR;

namespace EventSourcing.Application.Queries.GetUserHistory;

public class GetUserHistoryQueryRequest : IRequest<GetUserHistoryResponse>
{
    public int Id { get; set; } 
}
