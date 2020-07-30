using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Application.Users.Commands;
using Tandem.Domain.Users;

namespace Tandem.Application.Tests.Unit.Users.Commands.CreateUserCommandDomainExtensionsTests
{
    /// <summary>
    /// Unit tests for the ToUserEntity method of the
    /// <see cref="CreateUserCommandDomainExtensions"/> class
    /// </summary>
    [TestClass]
    public class ToUserEntityTest
    {
        /// <summary>
        /// Tests that the data in the command is properly mapped to the properties
        /// of the returned <see cref="User"/> entity.
        /// </summary>
        [TestMethod]
        public void ShouldMapCommandDataToEntityProperties()
        {
            CreateUserCommand command = new CreateUserCommand()
            {
                FirstName = "Some",
                MiddleName = "Kindof",
                LastName = "User",
                EmailAddress = "some@user.foo",
                PhoneNumber = "999-999-9999"
            };

            User user = command.ToUserEntity();

            Assert.AreEqual(command.FirstName, user.Name.First);
            Assert.AreEqual(command.MiddleName, user.Name.Middle);
            Assert.AreEqual(command.LastName, user.Name.Last);
            Assert.AreEqual(command.PhoneNumber, user.PhoneNumber.Value);
            Assert.AreEqual(command.EmailAddress, user.EmailAddress.Value);
        }
    }
}