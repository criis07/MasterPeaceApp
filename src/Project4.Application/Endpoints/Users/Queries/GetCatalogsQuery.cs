using MediatR;
using Project4.Application.DTO.Catalogs;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.Users.Queries
{
    public class GetCatalogsQuery : IRequest<EndpointResult<IEnumerable<CreateCatalogDTO>>>
    {
    }
}
