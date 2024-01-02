namespace EventSourcing.Domain
{
    public class ExampleModel : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
