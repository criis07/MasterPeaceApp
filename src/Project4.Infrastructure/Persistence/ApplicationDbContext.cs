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

        public DbSet<User> users { get; set; } = null!;

        public DbSet<Catalog> catalogs { get; set; }

        public DbSet<Batch> batch { get; set; }

        public DbSet<Product> products { get; set; }

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
            return base.SaveChangesAsync(cancellationToken);
        }
        //Constructor de nuestra estructura de datos
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.SeedData();
        } 
    }
}
