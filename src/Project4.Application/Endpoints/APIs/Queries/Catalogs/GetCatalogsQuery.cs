using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.APIs.Queries.Catalogs
{
    public class GetCatalogsQuery : IRequest<EndpointResult<IEnumerable<CreateCatalogDTO>>>
    {
    }
}
