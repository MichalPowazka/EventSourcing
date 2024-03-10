using EventSourcing.Domain.Events.Reservations;
using EventStore.Client;
using System.Text.Json;

namespace EventSourcing.Persistance.Repositories;
public class ReservationRepository(EventStoreClient _client) : IReservationRepository
{
    private const string stream = "Reservation - ";
    public async IAsyncEnumerable<ReservationEvent> GetById(string id)
    {
        var readResult = await _client.ReadStreamAsync(Direction.Forwards, id, StreamPosition.Start, 100).ToListAsync();

        //seralizacja na kilku typów obiektów na podstawie Event Type
        foreach (var resolved in readResult)
        { var a = JsonSerializer.Deserialize<ReservationEvent>(resolved.Event.Data.Span);
            yield return a;
        }
    }

    public async Task Save(ReservationEvent reservationEvent)
    {
        var streamName = reservationEvent.Reservation.ToString();
        var eventData = new EventData(
            Uuid.NewUuid(),
            reservationEvent.GetType().Name,
            JsonSerializer.SerializeToUtf8Bytes(reservationEvent));

        await _client.AppendToStreamAsync(streamName, StreamState.Any, new[] { eventData });
    }

    public async Task Test()
    {
        var eventData = new EventData(
            Uuid.NewUuid(),
           "createRoom",
            JsonSerializer.SerializeToUtf8Bytes(new ReservationEvent()
            {
                Id = 1,
                TimeStamp = DateTime.UtcNow
            }));
        var streamName = $"{stream}{1}";

        await _client.AppendToStreamAsync(
            streamName,
            StreamState.NoStream,
            new List<EventData> {
        eventData
            }
        );
    }
}
