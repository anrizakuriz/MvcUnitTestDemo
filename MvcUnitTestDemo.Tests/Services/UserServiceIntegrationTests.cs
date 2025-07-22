using FluentAssertions;
using Xunit;
using MvcUnitTestDemo.Data;        // Adjust namespace as needed
using MvcUnitTestDemo.Models;
using MvcUnitTestDemo.Services;
using MvcUnitTestDemo.Tests.Data;

namespace MvcUnitTestDemo.Tests.Services;
public class UserServiceIntegrationTests : IClassFixture<DbContextTestFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly UserService _userService;

    public UserServiceIntegrationTests(DbContextTestFixture fixture)
    {
        _context = fixture.Context;
        _userService = new UserService(_context); // real implementation
    }

    [Fact]
    public async Task AddUser_ShouldInsertUser_WithCorrectData()
    {
        // Arrange
        var newUser = new User
        {
            Name = "Anriza Aziiz",
            Email = "anriza@example.com",
            DateOfBirth = new DateTime(1996, 9, 21),
            Address = "Salatiga",
            PhoneNumber = "08123456789"
        };

        // Act
        await _userService.AddUser(newUser);
        await _context.SaveChangesAsync(); // ensure data is persisted

        // Assert
        newUser.Id.Should().BeGreaterThan(0);

        var userInDb = await _context.Users.FindAsync(newUser.Id);
        userInDb.Should().NotBeNull();

        userInDb!.Name.Should().Be(newUser.Name);
        userInDb.Email.Should().Be(newUser.Email);
        userInDb.DateOfBirth.Should().Be(newUser.DateOfBirth);
        userInDb.Address.Should().Be(newUser.Address);
        userInDb.PhoneNumber.Should().Be(newUser.PhoneNumber);
    }
}