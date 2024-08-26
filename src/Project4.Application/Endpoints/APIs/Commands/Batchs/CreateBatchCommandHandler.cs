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

namespace Project4.Application.Endpoints.Users.Commands.Batchs
{
    public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand, EndpointResult<CreateBatchResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBatchService _batchService;
        public CreateBatchCommandHandler(IMapper mapper, IBatchService batchService)
        {
            _mapper = mapper;
            _batchService = batchService;
        }

        public async Task<EndpointResult<CreateBatchResponse>> Handle(CreateBatchCommand request, CancellationToken cancellationToken)
        {
            var result = await _batchService.CreateBatchAsync(request);
            return new EndpointResult<CreateBatchResponse>(result);

        }
    }
}
