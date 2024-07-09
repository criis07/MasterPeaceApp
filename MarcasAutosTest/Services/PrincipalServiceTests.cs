using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;
using Project4.Api.Services;
using Project4.Api.Exceptions;

namespace Project4.Api.Tests.Services
{
    public class PrincipalServiceTests
    {
        [Fact]
        public void UserId_ReturnsCorrectId_WhenUserExists()
        {
            // Arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "123")
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var principalService = new PrincipalService(httpContextAccessorMock.Object);

            // Act
            var userId = principalService.UserId;

            // Assert
            Assert.Equal(123, userId);
        }

        [Fact]
        public void UserId_ThrowsException_WhenClaimsPrincipalIsNull()
        {
            // Arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns((ClaimsPrincipal)null);

            var principalService = new PrincipalService(httpContextAccessorMock.Object);

            // Act & Assert
            var ex = Assert.Throws<MissingClaimsPrincipalException>(() => principalService.UserId);

            // Assert
            Assert.NotNull(ex); // Verifica que se haya lanzado una excepción
        }

        [Fact]
        public void UserId_ReturnsDefaultId_WhenNameIdentifierClaimIsMissing()
        {
            // Arrange
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, "test@example.com")
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var principalService = new PrincipalService(httpContextAccessorMock.Object);

            // Act
            var userId = principalService.UserId;

            // Assert
            Assert.Equal(0, userId); // Default value when NameIdentifier claim is missing
        }
        [Fact]
        public void UserId_ReturnsParsedId_WhenNameIdentifierClaimIsPresent()
        {
            // Arrange
            var expectedUserId = 456;
            var httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, expectedUserId.ToString())
            };
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            httpContextAccessorMock.Setup(x => x.HttpContext.User).Returns(claimsPrincipal);

            var principalService = new PrincipalService(httpContextAccessorMock.Object);

            // Act
            var userId = principalService.UserId;

            // Assert
            Assert.Equal(expectedUserId, userId); // Verifica el valor devuelto cuando el claim NameIdentifier está presente
        }
    }
}
