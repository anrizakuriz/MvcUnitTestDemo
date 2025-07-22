using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUnitTestDemo.Controllers;
using MvcUnitTestDemo.Data;
using MvcUnitTestDemo.Models;
using MvcUnitTestDemo.Services;
using MvcUnitTestDemo.Tests.Data;

namespace MvcUnitTestDemo.Tests.Services
{
    public class UserServiceUnitTests : IClassFixture<DbContextTestFixture>
    {
        private readonly ApplicationDbContext _context;
        private readonly UserService _userService;

        public UserServiceUnitTests(DbContextTestFixture fixture)
        {
            _context = fixture.Context;
            _userService = new UserService(_context); // real implementation
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetUserById_ShouldReturnNull(int userId)
        {
            // Arrange
            //A.CallTo(() => _context.).Returns(Task.FromResult(users));

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            result.Should().BeNull();
        }
    }
}
