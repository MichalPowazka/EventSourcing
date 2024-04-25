namespace EventSourcing.Persistance.Repositories;

public interface IAggreagte<T>

{
    IAsyncEnumerable<T> GetById(string id);
    Task Save(T @event);
    Task CreateStream(T @event);

}
