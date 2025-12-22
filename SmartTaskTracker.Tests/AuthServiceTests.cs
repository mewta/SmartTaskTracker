using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartTaskTracker.API.Data;
using SmartTaskTracker.API.DTOs.Auth;
using SmartTaskTracker.API.Services;
using Xunit;
using System.Collections.Generic;

public class AuthServiceTests
{
    private AppDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("AuthTestDb")
            .Options;

        return new AppDbContext(options);
    }

    private IConfiguration GetTestConfiguration()
    {
        var settings = new Dictionary<string, string>
        {
            { "Jwt:Key", "THIS_IS_A_VERY_LONG_SECRET_KEY_FOR_TESTING_123456" },
            { "Jwt:Issuer", "SmartTaskTracker" },
            { "Jwt:Audience", "SmartTaskTrackerUsers" }
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(settings)
            .Build();
    }

    [Fact]
    public void Register_Then_Login_Returns_Token()
    {
        // Arrange
        var db = GetDbContext();
        var config = GetTestConfiguration();
        var jwt = new SmartTaskTracker.API.Helpers.JwtTokenGenerator(config);

        var service = new AuthService(db, jwt);

        var registerDto = new RegisterDto
        {
            Email = "test@mail.com",
            Password = "password123"
        };

        var loginDto = new LoginDto
        {
            Email = "test@mail.com",
            Password = "password123"
        };

        // Act
        service.Register(registerDto);
        var token = service.Login(loginDto);

        // Assert
        Assert.False(string.IsNullOrEmpty(token));
    }
}

