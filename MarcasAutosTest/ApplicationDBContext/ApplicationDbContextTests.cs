using Microsoft.EntityFrameworkCore;
using Moq;
using Project4.Application.Endpoints.MarcasAutos;
using Project4.Application.Interfaces.Services;
using Project4.Domain.Entities;
using Project4.Infrastructure.Persistence;
using System.Threading;
using Xunit;

namespace Project4.Infrastructure.Tests.Persistence
{
    public class ApplicationDbContextTests
    {
        [Fact]
        public async Task SaveChangesAsync_SetsAuditableProperties()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "test_db")
                .Options;

            var principalServiceMock = new Mock<IPrincipalService>();
            principalServiceMock.Setup(x => x.UserId).Returns(1); // Mock user ID
            var dateTimeServiceMock = new Mock<IDateTimeService>();
            dateTimeServiceMock.Setup(x => x.UtcNow).Returns(DateTime.UtcNow); // Mock current date time

            using (var context = new ApplicationDbContext(options, principalServiceMock.Object, dateTimeServiceMock.Object))
            {
                var entity = new Domain.Entities.MarcasAutos { Name = "Toyota" };
                context.marcas_autos.Add(entity);
                await context.SaveChangesAsync();
            }

            using (var context = new ApplicationDbContext(options, principalServiceMock.Object, dateTimeServiceMock.Object))
            {
                // Act
                var entity = await context.marcas_autos.SingleAsync();
                Assert.Equal(1, entity.Id);
            }
        }
    }
}
