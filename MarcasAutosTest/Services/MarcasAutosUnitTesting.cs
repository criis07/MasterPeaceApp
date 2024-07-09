using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project4.Application.Interfaces.Services;
using Project4.Domain.Entities;
using Project4.Infrastructure.Persistence;
using Project4.Infrastructure.Persistence.DataServices.MarcasAutoService;
using Xunit;

public class MarcasAutosUnitTesting
{
    private readonly DbContextOptions<ApplicationDbContext> _options;
    private readonly Mock<IPrincipalService> _principalServiceMock;
    private readonly Mock<IDateTimeService> _dateTimeServiceMock;
    private readonly Mock<DbSet<MarcasAutos>> _marcasAutosDbSetMock;

    public MarcasAutosUnitTesting()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Asegura una base de datos en memoria nueva para cada prueba
            .Options;

        _principalServiceMock = new Mock<IPrincipalService>();
        _dateTimeServiceMock = new Mock<IDateTimeService>();
        _marcasAutosDbSetMock = new Mock<DbSet<MarcasAutos>>();
    }

    private async Task SeedData(ApplicationDbContext context, params MarcasAutos[] marcas)
    {
        context.marcas_autos.AddRange(marcas);
        await context.SaveChangesAsync();
    }

    [Fact]
    public async Task GetAllMarcasAutos_ReturnsCorrectData()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            await SeedData(context,
                new MarcasAutos { Id = 1, Name = "Yaris" },
                new MarcasAutos { Id = 2, Name = "Celica" },
                new MarcasAutos { Id = 3, Name = "Supra" }
            );
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();

            Assert.Equal(3, result.Count());
            Assert.Contains(result, r => r.Name == "Yaris");
            Assert.Contains(result, r => r.Name == "Celica");
            Assert.Contains(result, r => r.Name == "Supra");
        }
    }

    [Fact]
    public async Task GetAllMarcasAutos_ReturnsEmptyListWhenNoData()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            context.marcas_autos.RemoveRange(context.marcas_autos);
            await context.SaveChangesAsync();
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();
            Assert.Empty(result);
        }
    }

    [Fact]
    public async Task GetAllMarcasAutos_ReturnsObjectsInBD()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            await SeedData(context,
                new MarcasAutos { Id = 4, Name = "Chevrolet" },
                new MarcasAutos { Id = 5, Name = "Picanto" }
            );
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();
            Assert.Contains(result, r => r.Name == "Chevrolet");
            Assert.Contains(result, r => r.Name == "Picanto");
        }
    }

    [Fact]
    public async Task GetAllMarcasAutos_ReturnsCorrectCount()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            await SeedData(context,
                new MarcasAutos { Id = 6, Name = "Civic" },
                new MarcasAutos { Id = 7, Name = "Accord" },
                new MarcasAutos { Id = 8, Name = "CR-V" }
            );
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();

            Assert.Equal(3, result.Count());
        }
    }

    [Fact]
    public async Task GetAllMarcasAutos_HandlesNoDataGracefully()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            context.marcas_autos.RemoveRange(context.marcas_autos);
            await context.SaveChangesAsync();
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();

            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
