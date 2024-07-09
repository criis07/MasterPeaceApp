using Project4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project4.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{
    DbSet<Person> People { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
