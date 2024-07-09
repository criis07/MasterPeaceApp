using MediatR;
using Project4.Domain.Entities;
using Project4.Application.Models;
using Project4.Application.DTO;

namespace Project4.Application.Endpoints.MarcasAutos.Queries
{
    public class MarcasAutosQuery : IRequest<EndpointResult<IEnumerable<MarcasAutosDTO>>>
    {

    }
}
