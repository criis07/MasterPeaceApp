using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.Configuration
{
    public class CatalogsConfiguration : IEntityTypeConfiguration<Catalog>
    {
        public void Configure(EntityTypeBuilder<Catalog> builder)
        {
            builder.ToTable("Catalogs");
            builder.HasKey(propertyName => propertyName.CatalogId);
            builder.Property(propertyName => propertyName.CatalogId).ValueGeneratedOnAdd();

            builder.HasIndex(propertyName => propertyName.ProductCode).IsUnique();

        }
    }
}
