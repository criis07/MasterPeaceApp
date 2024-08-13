using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Project4.Application.DTO.Catalogs;
using Project4.Application.DTO.Users;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class CatalogCommandHandler : IRequestHandler<CatalogCommand, EndpointResult<CreateCatalogResponse>>
    {
        private readonly ICatalogService _catalogService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CatalogCommandHandler(ICatalogService catalogService, IConfiguration configuration, IMapper mapper)
        {
            _catalogService = catalogService;
            _configuration = configuration;
            _mapper = mapper;   
        }


        public async Task<EndpointResult<CreateCatalogResponse>> Handle(CatalogCommand request, CancellationToken cancellationToken)
        {

            var catalog = _mapper.Map<CreateCatalogDTO>(request);

            var result = await _catalogService.CreateCatalogAsync(catalog);

            return new EndpointResult<CreateCatalogResponse>(result);
        }
    }
}
