using Project4.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project4.Infrastructure.Persistence.Configuration;

public class MarcasAutosConfiguration : IEntityTypeConfiguration<MarcasAutos>
{
    public void Configure(EntityTypeBuilder<MarcasAutos> builder)
    {
        builder.ToTable("marcas_autos");

        builder.Property(t => t.Id)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
