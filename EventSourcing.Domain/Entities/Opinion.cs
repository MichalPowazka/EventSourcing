namespace EventSourcing.Domain.Entities;

public class Opinion
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public User User { get; set; }
}
