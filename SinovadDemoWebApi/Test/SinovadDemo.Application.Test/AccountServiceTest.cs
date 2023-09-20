using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemo.Application.Test
{
    [TestClass]
    public class UserServiceTest
    {

        private static WebApplicationFactory<Program> _factory=null;
        private static IServiceScopeFactory _scopeFactory=null;


        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        //[TestMethod]
        //public void Login_WhenParametersAreEmpty_ShowValidatorErrorMessage()
        //{
        //    using var scope = _scopeFactory.CreateScope();
        //    var context = scope.ServiceProvider.GetService<IUserService>();

        //    //Arrange
        //    var accessUserDto = new AccessUserDto();
        //    accessUserDto.UserName = string.Empty;
        //    accessUserDto.Password = string.Empty;
        //    var expected = "Validation errors";

        //    //Act
        //    var result = context.Login(accessUserDto).Result;
        //    var actual = result.Message;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void Login_WhenParametersAreRight_ShowSuccessMessage()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IAuthenticationService>();

            //Arrange
            var accessUserDto = new AuthenticateUserDto();
            accessUserDto.UserName = "jvsv1994";
            accessUserDto.Password = "alfondo28V.";
            var expected = "Successful";

            //Act
            var result = context.AuthenticateUser(accessUserDto).Result;
            var actual = result.Message;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void Login_WhenParametersAreIncorrect_ShowInvalidAccessMessage()
        //{
        //    using var scope = _scopeFactory.CreateScope();
        //    var context = scope.ServiceProvider.GetService<IUserService>();

        //    //Arrange
        //    var accessUserDto = new AccessUserDto();
        //    accessUserDto.UserName = "jvsv1994";
        //    accessUserDto.Password = "alfondo28V.";
        //    var expected = "Invalid access";

        //    //Act
        //    var result = context.Login(accessUserDto).Result;
        //    var actual = result.Message;

        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}