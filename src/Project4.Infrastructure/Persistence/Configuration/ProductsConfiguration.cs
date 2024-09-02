using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(propertyName => propertyName.ProductId);
            builder.Property(propertyName => propertyName.ProductId).ValueGeneratedOnAdd();

            builder.HasOne(propertyName => propertyName.Batch)
                .WithMany(propertyName => propertyName.Products)
                .HasForeignKey(propertyName => propertyName.BatchId);

            builder.HasOne(propertyName => propertyName.Catalog)
                .WithMany(propertyName => propertyName.Products)
                .HasForeignKey(propertyName => propertyName.ProductCodeId);

        } 
    }
}
