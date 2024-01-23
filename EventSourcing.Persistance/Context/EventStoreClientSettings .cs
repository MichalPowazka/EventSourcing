using EventStore.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventSourcing.Persistance.Context
{
    public class EventStoreClientProvider
    {
        private readonly EventStoreClient _client;

        public EventStoreClientProvider()
        {
            // Konfiguracja połączenia z EventStoreDB dla klienta gRPC
            var settings = new EventStoreClientSettings
            {
                // Tu skonfiguruj swoje ustawienia, na przykład:
                ConnectivitySettings = {
                    Address = new Uri("esdb://localhost:2113?tls=false")
                }
                // Możesz też skonfigurować inne ustawienia, jeśli jest taka potrzeba
            };
            _client = new EventStoreClient(settings);
        }

        public EventStoreClient GetClient()
        {
            return _client;
        }
    }
}