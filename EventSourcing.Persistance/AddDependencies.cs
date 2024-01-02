using EventSourcing.Application.Interfaces;
using EventSourcing.Persistance.Repositories;
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
            services.AddScoped<IExampleRepository, ExampleRepository>();


            return services;
        }
    }
}
