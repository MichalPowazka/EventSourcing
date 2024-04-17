using EventSourcing.Domain.Events.Reservations;
using EventStore.Client;
using System.Text.Json;

namespace EventSourcing.Persistance.Repositories;
public class ReservationRepository(EventStoreClient _client) : IReservationRepository
{
    public async Task CreateStream(ReservationEvent reservationEvent)
    {

        var streamName = reservationEvent.RoomStream.ToString();
        var eventData = new EventData(
            Uuid.NewUuid(),
            reservationEvent.GetType().Name,
            JsonSerializer.SerializeToUtf8Bytes(reservationEvent));
        await _client.AppendToStreamAsync(streamName, StreamState.NoStream, new[] { eventData });
    }

    public async IAsyncEnumerable<ReservationEvent> GetById(string id)
    {
        var readResult = await _client.ReadStreamAsync(Direction.Forwards, id, StreamPosition.Start, 100).ToListAsync();

        //seralizacja na kilku typów obiektów na podstawie Event Type
        foreach (var resolved in readResult)
        {
            var a = JsonSerializer.Deserialize<ReservationEvent>(resolved.Event.Data.Span);
            yield return a;
        }

    }

    public async Task Save(ReservationEvent reservationEvent)
    {

        var readResult = await _client.ReadStreamAsync(Direction.Forwards, reservationEvent.RoomStream.ToString(), StreamPosition.Start, 100).ToListAsync();
        var clientOneRevision = readResult.Last().Event.EventNumber.ToUInt64();

        var streamName = reservationEvent.RoomStream.ToString();
        var eventData = new EventData(
            Uuid.NewUuid(),
            reservationEvent.GetType().Name,
            JsonSerializer.SerializeToUtf8Bytes(reservationEvent));
        await _client.AppendToStreamAsync(streamName, clientOneRevision, new[] { eventData });


    }


}
