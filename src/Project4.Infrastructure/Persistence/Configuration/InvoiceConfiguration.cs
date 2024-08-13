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
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(propertyName =>  propertyName.InvoiceId);
            builder.Property(propertyName => propertyName.InvoiceId).ValueGeneratedOnAdd();

            builder.HasOne(propertyName => propertyName.Product)
                .WithMany(propertyName => propertyName.Invoices)
                .HasForeignKey(propertyName => propertyName.ProductId);  
        }
    }
}
