using MediatR;
using Project4.Domain.Entities;
using Project4.Application.Models;

namespace Project4.Application.Endpoints.MarcasAutos.Queries
{
    public class MarcasAutosQuery : IRequest<EndpointResult<IEnumerable<MarcasAutos>>>
    {

    }
}
