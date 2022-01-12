using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookLibraryProject.Controllers;
using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using NUnit.Framework;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
namespace BookLibrary.Auth.Tests
{
    [TestFixture]
    public class AccountControllerTests
    {
        private AccountController accountController { get; }
        ////public object loginDto { get; private set; }
        //public LoginDto login { get; set; }
        //Arrange
        private const string email = "eddie@gmail.com";
        private const string Username = "a";
        private const string Password = "Pa$$w0rd";
        public AccountControllerTests()
        {
            AppUser user = new AppUser
            {
                UserName = "admin",
                Gender = "male"
            };
            LoginDto login = new LoginDto
            {
                Password = "Pa$$w0rd",
                Username = "admin"
            };
            List<string> roles = new List<string> { "Admin" };
            var _userMgr = new Mock<UserManager<AppUser>>(Mock.Of<IUserStore<AppUser>>(), null, null, null, null, null,
                null, null, null);
            _userMgr.Setup(x => x.FindByNameAsync(login.Username)).ReturnsAsync(user);
            //_userMgr.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(roles);
            //_userMgr.Setup(x => x.CheckPasswordAsync(user, login.Password)).ReturnsAsync(true);
            var mockMapper = new Mock<IMapper>();
            var mockTokenSer = new Mock<ITokenService>();
            var _contextAccessor = new Mock<IHttpContextAccessor>();
            var _userPrincipalFactory = new Mock<IUserClaimsPrincipalFactory<AppUser>>();
            var _signInMgr = new Mock<SignInManager<AppUser>>(_userMgr.Object,
                _contextAccessor.Object, _userPrincipalFactory.Object, null, null, null, null);
            _signInMgr.Setup(x => x.CheckPasswordSignInAsync(user, Password, false)).ReturnsAsync(SignInResult.Success);
            accountController = new AccountController(_userMgr.Object, _signInMgr.Object, mockTokenSer.Object, mockMapper.Object);
        }
        //[Fact]
        [Test]
        public async Task Login()
        {
            LoginDto login = new LoginDto
            {
                Password = "Pa$$w0rd",
                Username = "admin"
            };
            //Act
            var result = await accountController.Login(login);
            //Assert
            Assert.IsNotNull(result);
        }
        [Theory]
        [TestCase("user", Password)]
        [TestCase(Username, "")]
        public async Task InvalidUserNameTest(string username, string password)
        {
            LoginDto login = new LoginDto
            {
                Password = password,
                Username = username
            };
            //Act
            var result = await accountController.Login(login);
            //Assert
            Assert.IsFalse(result.Value);
            //Assert.That(contResut, Is.InstanceOf<ActionResult>());
        }
    }
}