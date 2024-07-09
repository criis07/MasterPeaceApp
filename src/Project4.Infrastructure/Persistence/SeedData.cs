using Project4.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Project4.Infrastructure.Persistence;

public static class SeedDataExtension
{
    public static void SeedData(this ModelBuilder builder)
    {
        // TODO: Use this file to seed the database with any initial data that
        // should exist the first time the application is run.

        builder.Entity<MarcasAutos>().HasData(
            new MarcasAutos { Id = 1, Name = "Yaris" },
            new MarcasAutos { Id = 2, Name = "Celica" },
            new MarcasAutos { Id = 3, Name = "Supra" }
        );
    }
}
