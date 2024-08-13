using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Queries
{
    public class GetCatalogsQueryHandler : IRequestHandler<GetCatalogsQuery, EndpointResult<IEnumerable<CreateCatalogDTO>>>
    {
        private readonly ICatalogService _catalogService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public GetCatalogsQueryHandler(ICatalogService catalogService, IConfiguration configuration, IMapper mapper)
        {
            _catalogService = catalogService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<EndpointResult<IEnumerable<CreateCatalogDTO>>> Handle(GetCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogList = await _catalogService.GetAllCatalogsAsync(cancellationToken);

            var catalogs = _mapper.Map<CreateCatalogDTO[]>(catalogList);

            return new EndpointResult<IEnumerable<CreateCatalogDTO>>(catalogs);
        }
    }
}
