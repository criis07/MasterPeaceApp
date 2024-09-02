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
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.ToTable("Product_detail");
            builder.HasKey(propertyName => propertyName.ProductDetailId);
            builder.Property(propertyName => propertyName.ProductDetailId).ValueGeneratedOnAdd();

            builder.HasOne(propertyName => propertyName.Product)
                .WithMany(propertyName => propertyName.ProductDetails)
                .HasForeignKey(propertyName => propertyName.ProductId);
        }
    }
}
