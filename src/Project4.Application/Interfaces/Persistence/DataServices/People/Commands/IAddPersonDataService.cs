using Project4.Domain.Entities;

namespace Project4.Application.Interfaces.Persistence.DataServices.People.Commands;

public interface IAddPersonDataService
{
    Task<Person> ExecuteAsync(Person person, CancellationToken cancellationToken = default);
}

