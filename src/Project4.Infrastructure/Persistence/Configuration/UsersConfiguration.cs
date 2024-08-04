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
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn().ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(25);
            builder.Property(x => x.LastName).HasMaxLength(25);

            builder.Property(x=> x.Password).HasMaxLength(150);
        }
    }
}
