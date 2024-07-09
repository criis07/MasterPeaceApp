using System.Reflection;
using Project4.Application.Interfaces.Persistence;
using Project4.Application.Interfaces.Services;
using Project4.Domain.Common;
using Project4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project4.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IPrincipalService _principalService;
        private readonly IDateTimeService _dateTimeService;

        public DbSet<MarcasAutos> marcas_autos { get; set; } = null!;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IPrincipalService principalService,
            IDateTimeService dateTimeService) : base(options)
        {
            _principalService = principalService;
            _dateTimeService = dateTimeService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.CreatedBy = _principalService.UserId;
                        entity.Entity.CreatedOn = _dateTimeService.UtcNow;
                        break;
                    case EntityState.Modified:
                        entity.Entity.ModifiedBy = _principalService.UserId;
                        entity.Entity.ModifiedOn = _dateTimeService.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.SeedData();
        }
    }
}
