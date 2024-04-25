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
            var settings = new EventStoreClientSettings
            {
          
                ConnectivitySettings = {
                    Address = new Uri("esdb://localhost:2113?tls=false")
                }
                
            };
            _client = new EventStoreClient(settings);
        }
        public EventStoreClient GetClient()
        {
            return _client;
        }
    }
}