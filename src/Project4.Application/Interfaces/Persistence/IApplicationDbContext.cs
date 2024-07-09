using Project4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project4.Application.Interfaces.Persistence;

public interface IApplicationDbContext
{

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
