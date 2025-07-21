using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUnitTestDemo.Controllers;
using MvcUnitTestDemo.Models;
using MvcUnitTestDemo.Services;

namespace MvcUnitTestDemo.Tests.Controller
{
    public class HomeControllerTests
    {
        private readonly HomeController _homeController;
        private readonly IUserService _userService;
        private readonly ILogger<HomeController> _logger;

        public HomeControllerTests()
        {
            _userService = A.Fake<IUserService>();
            _logger = A.Fake<ILogger<HomeController>>();

            _homeController = new HomeController(_logger, _userService);
        }

        [Fact]
        public async Task Index_ReturnsActionResult()
        {
            // Arrange
            var users = A.Fake<List<User>>();
            A.CallTo(() => _userService.GetAllUsers()).Returns(users);

            // Act
            var result = await _homeController.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task Index_ReturnsViewWithAllUsers()
        {
            // Arrange
            var users = A.Fake<List<User>>();

            // pakai A.CallTo dibawah ini untuk mengembalikan data palsu
            A.CallTo(() => _userService.GetAllUsers()).Returns(Task.FromResult(users));

            // pakai A.CallTo dibawah ini untuk mengembalikan exception
            //A.CallTo(() => _userService.GetAllUsers()).Throws<NotImplementedException>();


            // Act
            var result = await _homeController.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
            

            var viewResult = result as ViewResult;
            viewResult!.Model.Should().BeEquivalentTo(users);
        }

        [Fact]
        public async Task Index_CallsGetAllUsers_FromUserService()
        {
            // Arrange
            var users = A.Fake<List<User>>();
            A.CallTo(() => _userService.GetAllUsers()).Returns(Task.FromResult(users));

            // Act
            await _homeController.Index();

            // Assert
            A.CallTo(() => _userService.GetAllUsers())
                .MustHaveHappenedOnceExactly();
        }


    }
}
