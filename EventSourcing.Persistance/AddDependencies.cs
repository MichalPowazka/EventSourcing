﻿using EventSourcing.Domain.Events.Reservations;
using EventSourcing.Domain.Events.Users;
using EventSourcing.Persistance.Repositories;
using EventStore.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EventSourcing.Persistance
{
    public static class AddDependencies
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            var a = EventStoreClientSettings.Create("esdb://127.0.0.1:2113/?tls=false");
  

            var client = new EventStoreClient(a);
            services.AddSingleton<EventStoreClient>(client);
            services.AddScoped<IAggreagte<ReservationEvent>, ReservationRepository>();
            services.AddScoped<IAggreagte<UserEvent>, UserEventsRepository>();

            return services;
        }
    }
}
