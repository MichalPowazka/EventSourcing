namespace EventSourcing.Application.Queries.GetUserHistory;

public class GetUserHistoryResponse
{
    public List<UserHistoryDto> History { get; set; }
}



public class UserHistoryDto
{
    public DateTime DateTime { get; set; }
    public string Type { get; set; }
    public string UserNakme { get; set; }
}