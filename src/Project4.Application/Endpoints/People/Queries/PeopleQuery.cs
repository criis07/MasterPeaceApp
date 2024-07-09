using Project4.Application.Models;
using MediatR;

namespace Project4.Application.Endpoints.People.Queries;

public class PeopleQuery : IRequest<EndpointResult<IEnumerable<PersonViewModel>>>
{
    public bool IncludeInactive { get; init; } = false;
}

