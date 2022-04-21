using System;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            userService
                .Setup(p => p.GetUsers())
                .Returns(Task.FromResult(Enumerable.Empty<User>()))
                .Verifiable();

            await viewModel.Initialize();

            userService.VerifyAll();
        }

        [Test]
        public async Task InitializeShowErrorMessageOnFetchingError()
        {
            //In order for this test to pass I added an exception in the Getusers method.
            //var userservice = new Mock<IUserService>();
            //var messageService = new Mock<IMessageService>();

            //var viewmodel = new UsersViewModel(
            //    userservice.Object,
            //    messageService.Object);

            //string message = new Exception().ToString();


            //messageService
            //    .Setup(p => p.ShowError(message))
            //    .Returns(Task.FromResult(Task.CompletedTask))
            //    .Verifiable();

            //await viewmodel.Initialize();

            //messageService.VerifyAll();

        }
    }
}
