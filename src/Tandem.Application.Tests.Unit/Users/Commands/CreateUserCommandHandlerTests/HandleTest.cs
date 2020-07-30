using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using Tandem.Application.Users.Commands;
using Tandem.Domain.Users;

namespace Tandem.Application.Tests.Unit.Users.Commands.CreateUserCommandHandlerTests
{
    /// <summary>
    /// Unit tests for the Handle method of the <see cref="CreateUserCommandHandler"/>
    /// class.
    /// </summary>
    [TestClass]
    public class HandleTest
    {
        /// <summary>
        /// Tests that passing a null request argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public async Task NullRequestShouldThrowException()
        {
            CreateUserCommandHandler handler = CreateHandler();

            ArgumentNullException exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                () => handler.Handle(null, CancellationToken.None));

            Assert.AreEqual<string>("request", exception.ParamName);
        }

        /// <summary>
        /// Tests that the expected user is saved to the repository.
        /// </summary>
        [TestMethod]
        public async Task Should()
        {
            CreateUserCommand command = CreateCommand();

            userRepositoryMock
                .Setup(repository => repository.SaveUserAsync(
                    It.Is<User>(user
                        => user.Name.First == command.FirstName
                        && user.Name.Middle == command.MiddleName
                        && user.Name.Last == command.LastName
                        && user.PhoneNumber.Value == command.PhoneNumber
                        && user.EmailAddress.Value == command.EmailAddress)
                    )
                );

            CreateUserCommandHandler handler = CreateHandler();

            await handler.Handle(command, CancellationToken.None);

            userRepositoryMock.VerifyAll();
;       }

        /// <summary>
        /// Tests that the newly created user Id is returned to the caller.
        /// </summary>
        [TestMethod]
        public async Task NewUserIdShouldReturnToCaller()
        {
            CreateUserCommand command = CreateCommand();
            Guid capturedUserId = Guid.Empty;

            userRepositoryMock
                .Setup(repository => repository.SaveUserAsync(It.IsAny<User>()))
                .Callback<User>(user => capturedUserId = user.Id);

            CreateUserCommandHandler handler = CreateHandler();

            Guid userId = await handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(capturedUserId, userId);
        }

        private readonly Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

        /// <summary>
        /// Creates a new instance of the <see cref="CreateUserCommandHandler"/>
        /// class configured for testing.
        /// </summary>
        private CreateUserCommandHandler CreateHandler()
        {
            return new CreateUserCommandHandler(userRepositoryMock.Object);
        }

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
    }
}