using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Api.Users;

namespace Tandem.Api.Tests.Unit.Users.UsersControllerTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="UsersController"/> class.
    /// </summary>
    [TestClass]
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null mediator argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullMediatorShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new UsersController(null));
            Assert.AreEqual<string>("mediator", exception.ParamName);
        }
    }
}