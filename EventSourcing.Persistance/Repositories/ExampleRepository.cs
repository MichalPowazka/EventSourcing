using EventSourcing.Application.Interfaces;
using EventSourcing.Domain;
using EventSourcing.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Persistance.Repositories
{
    internal class ExampleRepository : IExampleRepository
    {
        public Task<ExampleModel> GetExampleModelById(long id) => Task.FromResult(InMemoryData.ExampleModelData.FirstOrDefault(e => e.Id == id));
    }
}
