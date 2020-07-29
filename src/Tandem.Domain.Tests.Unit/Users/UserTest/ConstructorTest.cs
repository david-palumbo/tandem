using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Domain.Users;

namespace Tandem.Domain.Tests.Unit.Users.UserTest
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="User"/> class.
    /// </summary>
    [TestClass]
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that a new instance of the <see cref="User"/> class has the
        /// expected state.
        /// </summary>
        [TestMethod]
        public void NewInstanceShouldHaveExpectedState()
        {
            User user = new User();

            Assert.AreNotEqual(Guid.Empty, user.Id);
        }
    }
}