﻿using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Domain.Events.Users;
using EventStore.Client;
using System.Text.Json;

namespace EventSourcing.Persistance.Repositories
{
    public class UserEventsRepository(EventStoreClient _client) : IUserEventsRepository
    {
        private const string stream = "User - ";
        public async IAsyncEnumerable<UserEvent> GetById(string id)
        {
            var readResult = await _client.ReadStreamAsync(Direction.Forwards, id, StreamPosition.Start, 100).ToListAsync();

            foreach (var resolved in readResult)
            {
                yield return JsonSerializer.Deserialize<UserEvent>(resolved.Event.Data.Span);
            }
        }

        public async Task Save(UserEvent reservationEvent)
        {
            var readResult = await _client.ReadStreamAsync(Direction.Forwards, reservationEvent.UniqueId.ToString(), StreamPosition.Start, 100).ToListAsync();
            var clientOneRevision = readResult.Last().Event.EventNumber.ToUInt64();
            var streamName = reservationEvent.UniqueId.ToString();
            var eventData = new EventData(
                Uuid.NewUuid(),
                reservationEvent.GetType().Name,
                JsonSerializer.SerializeToUtf8Bytes(reservationEvent));

            await _client.AppendToStreamAsync(streamName, clientOneRevision, new[] { eventData });
        }


    }
}
