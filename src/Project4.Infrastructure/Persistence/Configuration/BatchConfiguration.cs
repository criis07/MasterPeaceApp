using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project4.Domain.Entities;

namespace Project4.Infrastructure.Persistence.Configuration
{
    public class BatchConfiguration : IEntityTypeConfiguration<Batch>
    { 
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.ToTable("Batch");
            builder.HasKey(propertyName => propertyName.BatchId);
            builder.Property(propertyName => propertyName.BatchId).ValueGeneratedOnAdd();
        }
    }
}
