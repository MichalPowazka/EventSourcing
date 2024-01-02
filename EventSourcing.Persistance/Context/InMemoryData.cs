using EventSourcing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Persistance.Context
{
    /// <summary>
    /// create context here (EF CORE), in this case it is some in memory list
    /// </summary>
    internal static class InMemoryData
    {
        public static List<ExampleModel> ExampleModelData = new List<ExampleModel>()
        {
            new ExampleModel
            {
                Id = 1,
                Name = "XX"
            },
            new ExampleModel
            {
                Id = 2,
                Name = "dsa"
            }
        };
    }
}
