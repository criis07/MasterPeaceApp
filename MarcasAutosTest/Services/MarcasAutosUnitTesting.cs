using System.Linq;
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

    public MarcasAutosUnitTesting()
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Asegura una base de datos en memoria nueva para cada prueba
            .Options;

        _principalServiceMock = new Mock<IPrincipalService>();
        _dateTimeServiceMock = new Mock<IDateTimeService>();
    }
    //Valida que retorne la información correcta 
    [Fact]
    public async Task GetAllMarcasAutos_ReturnsCorrectData()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            context.marcas_autos.Add(new MarcasAutos { Id = 1, Name = "Yaris" });
            context.marcas_autos.Add(new MarcasAutos { Id = 2, Name = "Celica" });
            context.marcas_autos.Add(new MarcasAutos { Id = 3, Name = "Supra" });
            await context.SaveChangesAsync();
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
    //Valida que retorne una lista vacía cuando no hay datos
    [Fact]
    public async Task GetAllMarcasAutos_ReturnsEmptyListWhenNoData()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            // Asegurarse de que la base de datos esté limpia antes de la prueba
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
    //Valida que la base de datos tenga alguno o algunos datos en específico
    [Fact]
    public async Task GetAllMarcasAutos_ReturnsObjectsInBD()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            context.marcas_autos.Add(new MarcasAutos { Id = 4, Name = "Chevrolet" });
            context.marcas_autos.Add(new MarcasAutos { Id = 5, Name = "Picanto" });
            await context.SaveChangesAsync();
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();
            Assert.Contains(result, r => r.Name == "Chevrolet");
            Assert.Contains(result, r => r.Name == "Picanto");
        }
    }

    //Valida cuando se han insertado determinado numero de elementos y los devuelve correctamente
    [Fact]
    public async Task GetAllMarcasAutos_ReturnsCorrectCount()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            context.marcas_autos.Add(new MarcasAutos { Id = 6, Name = "Civic" });
            context.marcas_autos.Add(new MarcasAutos { Id = 7, Name = "Accord" });
            context.marcas_autos.Add(new MarcasAutos { Id = 8, Name = "CR-V" });
            await context.SaveChangesAsync();
        }

        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            var service = new MarcasAutosService(context);
            var result = await service.GetAllMarcasAutos();

            Assert.Equal(3, result.Count());
        }
    }

    //Valida cuando no hay data pero aun asi no retorna nulo
    [Fact]
    public async Task GetAllMarcasAutos_HandlesNoDataGracefully()
    {
        using (var context = new ApplicationDbContext(_options, _principalServiceMock.Object, _dateTimeServiceMock.Object))
        {
            // Asegurarse de que la base de datos esté limpia antes de la prueba
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
