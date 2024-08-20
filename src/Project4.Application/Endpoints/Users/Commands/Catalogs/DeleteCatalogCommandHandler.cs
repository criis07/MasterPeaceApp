using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Interfaces.Persistence.DataServices.Catalog;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Commands.Catalogs
{
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, EndpointResult<DeleteCatalogResponse>>
    {
        private readonly IMediator _mediator;
        private readonly ICatalogService _catalogService;

        public DeleteCatalogCommandHandler(IMediator mediator, ICatalogService catalogService)
        {
            _catalogService = catalogService;
            _mediator = mediator;
        }

        public async Task<EndpointResult<DeleteCatalogResponse>> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _catalogService.DeleteCatalogAsync(request.CatalogId);
            return new EndpointResult<DeleteCatalogResponse>(catalog);
        }
    }
}
