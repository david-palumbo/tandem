using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Tandem.Api.Users;
using Tandem.Application.Users.Commands;
using Tandem.Kernel;

namespace Tandem.Api.Tests.Unit.Users.UsersControllerTests
{
    /// <summary>
    /// Unit tests for the Post method of the <see cref="UsersController"/> class.
    /// </summary>
    [TestClass]
    public class PostTest
    {
        /// <summary>
        /// Tests that a bad request status code is return if a validation exception
        /// is thrown.
        /// </summary>
        [TestMethod]
        public async Task ValidationExceptionShouldReturnBadRequest()
        {
            CreateUserCommand command = CreateCommand();
            UsersController controller = CreateController();

            const string message = "uh-oh";

            mediatorMock
                .Setup(mediator => mediator.Send(command, CancellationToken.None))
                .ThrowsAsync(new ValidationException() {UserFriendlyMessage = message});

            IActionResult result = await controller.Post(command);

            BadRequestObjectResult actionResult = result as BadRequestObjectResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(400, actionResult.StatusCode);
            Assert.AreEqual(message, actionResult.Value);
        }

        /// <summary>
        /// Tests that a CreatedAt result is returned when the command succeeds.
        /// </summary>
        [TestMethod]
        public async Task ShouldReturnCreatedAtResult()
        {
            CreateUserCommand command = CreateCommand();
            UsersController controller = CreateController();
            Guid userId = Guid.NewGuid();

            mediatorMock
                .Setup(mediator => mediator.Send(command, CancellationToken.None))
                .ReturnsAsync(userId);

            IActionResult result = await controller.Post(command);

            CreatedAtActionResult actionResult = result as CreatedAtActionResult;

            Assert.IsNotNull(actionResult);
            Assert.AreEqual(201, actionResult.StatusCode);
            Assert.AreEqual(userId, actionResult.Value);
        }

        private readonly Mock<IMediator> mediatorMock = new Mock<IMediator>();

        /// <summary>
        /// Creates a new instance of the <see cref="CreateUserCommand"/>
        /// class configured for testing.
        /// </summary>
        private static CreateUserCommand CreateCommand()
        {
            CreateUserCommand command = new CreateUserCommand()
            {
                FirstName = "Some",
                MiddleName = "Kindof",
                LastName = "User",
                EmailAddress = "some@user.foo",
                PhoneNumber = "999-999-9999"
            };
            return command;
        }


        /// <summary>
        /// Creates a new instance of the <see cref="UsersController"/> class
        /// configured for testing.
        /// </summary>
        private UsersController CreateController()
        {
            return new UsersController(mediatorMock.Object);
        }
    }
}