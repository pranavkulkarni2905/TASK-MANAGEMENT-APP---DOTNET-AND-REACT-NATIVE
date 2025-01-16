using Moq;
using TaskManagementBackend.Application.Services;
using TaskManagementBackend.Core.Interfaces;
using Xunit;
using Microsoft.Extensions.Configuration;

namespace TaskManagementBackend.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly Mock<IConfiguration> _mockConfiguration;

        public AuthServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfiguration.Setup(c => c["Jwt:Key"]).Returns("TestSecretKey");
            _mockConfiguration.Setup(c => c["Jwt:Issuer"]).Returns("TestIssuer");
            _mockConfiguration.Setup(c => c["Jwt:Audience"]).Returns("TestAudience");

            _authService = new AuthService(_mockConfiguration.Object);
        }

        [Fact]
        public void GenerateJwtToken_ShouldReturnToken()
        {
            // Arrange
            int userId = 1;
            string username = "testuser";

            // Act
            var token = _authService.GenerateJwtToken(userId, username);

            // Assert
            Assert.False(string.IsNullOrEmpty(token));
        }

        [Fact]
        public void HashPassword_ShouldReturnHashedPassword()
        {
            // Arrange
            string password = "password123";

            // Act
            var hashedPassword = _authService.HashPassword(password);

            // Assert
            Assert.True(_authService.VerifyPassword(password, hashedPassword));
        }

        [Fact]
        public void VerifyPassword_ShouldReturnFalse_ForInvalidPassword()
        {
            // Arrange
            string password = "password123";
            string wrongPassword = "wrongPassword";
            var hashedPassword = _authService.HashPassword(password);

            // Act
            var result = _authService.VerifyPassword(wrongPassword, hashedPassword);

            // Assert
            Assert.False(result);
        }
    }
}
