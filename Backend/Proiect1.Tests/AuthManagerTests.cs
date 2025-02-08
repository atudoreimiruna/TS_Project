using Moq;
using Proiect1.BLL.Interfaces;
using Proiect1.BLL.Models;

namespace Proiect1.Tests;

public class AuthManagerTests : IClassFixture<AuthManagerFixture>
{
    private readonly IAuthManager _authManager;

    public AuthManagerTests(AuthManagerFixture fixture)
    {
        _authManager = fixture.AuthManager;
    }

    [Fact]
    public async Task Register_SuccessfulRegistration_ReturnsTrue()
    {
        // Arrange
        var registerModel = new RegisterModel
        {
            Email = "test@example.com",
            Password = "P@ssw0rd!",
            Role = "User"
        };

        // Act
        var result = await _authManager.Register(registerModel);

        // Assert
        Assert.True(result);
    }
}

public class AuthManagerFixture
{
    public IAuthManager AuthManager { get; }

    public AuthManagerFixture()
    {
        var authManagerMock = new Mock<IAuthManager>();

        authManagerMock.Setup(m => m.Register(It.IsAny<RegisterModel>()))
                       .ReturnsAsync(true); 

        AuthManager = authManagerMock.Object;
    }
}