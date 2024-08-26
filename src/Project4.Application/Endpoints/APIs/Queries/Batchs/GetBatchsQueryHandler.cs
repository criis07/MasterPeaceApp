using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO.Batchs;
using Project4.Application.Interfaces.Persistence.DataServices.Batch;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Queries.Batchs
{
    public class GetBatchsQueryHandler : IRequestHandler<GetBatchsQuery, EndpointResult<IEnumerable<BatchDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IBatchService _batchService;
        public GetBatchsQueryHandler(IMapper mapper, IBatchService batchService)
        {
            _mapper = mapper;
            _batchService = batchService;
        }
        public async Task<EndpointResult<IEnumerable<BatchDTO>>> Handle(GetBatchsQuery request, CancellationToken cancellationToken)
        {
            var result = await _batchService.GetAllAsync(cancellationToken);
            var response = _mapper.Map<BatchDTO[]>(result);
            return new EndpointResult<IEnumerable<BatchDTO>>(response);
        }
    }
}
