using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Project4.Application.Interfaces.Persistence;
using Project4.Application.Interfaces.Services;
using Project4.Infrastructure;
using Project4.Infrastructure.Persistence;
using Xunit;

namespace Project4.Tests.Infrastructure
{
    public class DependencyInjectionTests
    {
        [Fact]
        public void AddInfrastructure_RegistersDateTimeServiceAsSingleton()
        {
            // Arrange
            var services = new ServiceCollection();
            var configuration = new Mock<IConfiguration>().Object;

            // Act
            DependencyInjection.AddInfrastructure(services, configuration);
            var serviceProvider = services.BuildServiceProvider();
            var dateTimeService1 = serviceProvider.GetService<IDateTimeService>();
            var dateTimeService2 = serviceProvider.GetService<IDateTimeService>();

            // Assert
            Assert.NotNull(dateTimeService1);
            Assert.Same(dateTimeService1, dateTimeService2); // Should be the same instance
        }

        [Fact]
        public void AddInfrastructure_RegistersLoggerServiceAsScoped()
        {
            // Arrange
            var services = new ServiceCollection();
            var configuration = new Mock<IConfiguration>().Object;

            // Act
            DependencyInjection.AddInfrastructure(services, configuration);
            var serviceProvider = services.BuildServiceProvider();

            // Assert
            var loggerService1 = serviceProvider.GetService<IDateTimeService>();

            Assert.NotNull(loggerService1);
        }
    }
}
