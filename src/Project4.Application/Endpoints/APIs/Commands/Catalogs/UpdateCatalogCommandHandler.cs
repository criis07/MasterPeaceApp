using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Application.Models;
using Project4.Domain.Entities;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, EndpointResult<UpdateCatalogResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogService _catalogService;
        public UpdateCatalogCommandHandler(IMapper mapper, ICatalogService catalogService)
        {
            _catalogService = catalogService;
            _mapper = mapper;
        }

        public async Task<EndpointResult<UpdateCatalogResponse>> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var updateCatalog = _mapper.Map<UpdateCatalogDTO>(request);

            var result = await _catalogService.UpdateCatalogAsync(updateCatalog);

            return new EndpointResult<UpdateCatalogResponse>(result);

        }
    }
}
