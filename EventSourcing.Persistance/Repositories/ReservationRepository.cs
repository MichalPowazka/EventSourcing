using EventSourcing.Domain.Events;
using EventStore.Client;
using System.Text.Json;

namespace EventSourcing.Persistance.Repositories;

internal class ReservationRepository(EventStoreClient _client) : IReservationRepository
{
    private const string stream = "Reservation - ";
    public async IAsyncEnumerable<ReservationEvent> GetById(int id)
    {
        var streamName = $"{stream}{id}";
        var readResult =  await _client.ReadStreamAsync(Direction.Forwards, streamName, StreamPosition.Start, 100).ToListAsync();
        
        //seralizacja na kilku typów obiektów na podstawie Event Type
        foreach (var resolved in readResult)
        {
            switch (resolved.Event.EventType)
            {
                case "CreateReservationEvenet":
                    yield    return JsonSerializer.Deserialize<CreateReservationEvenet>(resolved.Event.Data.Span);
                    break;
                case "CancelReservationEvent":
                    yield return JsonSerializer.Deserialize<CancelReservationEvent>(resolved.Event.Data.Span);
                    break;
                default:
                    yield return JsonSerializer.Deserialize<ReservationEvent>(resolved.Event.Data.Span);
                    break;
            }

        }
    }

    public async Task Save(ReservationEvent reservationEvent)
    { 
        var streamName = $"{stream}{reservationEvent.Id}";
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
