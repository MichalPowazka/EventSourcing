using EventSourcing.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Queries.GetExampleModelById
{
    internal class GetExampleModelByIdHandler : IRequestHandler<GetExampleModelByIdRequest, GetExampleModelByIdResponse>
    {
        private readonly IExampleRepository _exampleRepository;
        public GetExampleModelByIdHandler(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository;
        }

        public async Task<GetExampleModelByIdResponse> Handle(GetExampleModelByIdRequest request, CancellationToken cancellationToken)
        {
            var res = await _exampleRepository.GetExampleModelById(request.Id);
            if (res is null) return null;

            var mappedRes = new GetExampleModelByIdResponse()
            {
                Name = res.Name
            };

            return mappedRes;
        }
    }
}
