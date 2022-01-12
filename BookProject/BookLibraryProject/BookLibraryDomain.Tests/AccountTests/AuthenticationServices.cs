using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibraryProject.Controllers;
using DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Models;
using Moq;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace BookLibraryDomain.Tests.AccountTests
{
    [TestFixture]
    public class AuthenticationServices
    {

        public void Login_WithCorrectPassWordForExistingUsername_ReturnsAccountForCorrectUsername()
        {
            //Arrange
            Mock<Microsoft.AspNet.Identity.UserManager<AppUser>> mock = new Mock<Microsoft.AspNet.Identity.UserManager<AppUser>>();
            Mock<IPasswordHasher> mockpass = new Mock<IPasswordHasher>();
            AccountController accountController = new AccountController(mock.Object, mockpass.Object);

            //Act


            //Assert
        }
    }
}
