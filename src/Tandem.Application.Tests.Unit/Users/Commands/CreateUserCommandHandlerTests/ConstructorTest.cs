using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Application.Users.Commands;

namespace Tandem.Application.Tests.Unit.Users.Commands.CreateUserCommandHandlerTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="CreateUserCommandHandler"/>
    /// class.
    /// </summary>
    [TestClass]
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null userRepository argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullUserRepositoryShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new CreateUserCommandHandler(null));
            Assert.AreEqual<string>("userRepository", exception.ParamName);
        }
    }
}