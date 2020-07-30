using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Domain.Users;
using Tandem.Kernel;

namespace Tandem.Domain.Tests.Unit.Users.PersonNameTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="PersonName"/> class.
    /// </summary>
    [TestClass]
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null firstName argument will result
        /// in an <see cref="ValidationException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullFirstNameShouldThrowException()
        {
            ValidationException exception = Assert.ThrowsException<ValidationException>(
                () => new PersonName(null, "Other", "User"));
            Assert.AreEqual<string>("First name is required.", exception.UserFriendlyMessage);
        }

        /// <summary>
        /// Tests that passing a null lastName argument will result
        /// in an <see cref="ValidationException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullLastShouldThrowException()
        {
            ValidationException exception = Assert.ThrowsException<ValidationException>(
                () => new PersonName("Some", "Other", null));
            Assert.AreEqual<string>("Last name is required.", exception.UserFriendlyMessage);
        }

        /// <summary>
        /// Tests that the firstName argument binds to the First property.
        /// </summary>
        [TestMethod]
        public void FirstNameArgumentShouldBindToProperty()
        {
            const string firstName = "Some";

            PersonName personName = new PersonName(firstName, null, "User");

            Assert.AreEqual(firstName, personName.First);
        }

        /// <summary>
        /// Tests that the middleName argument binds to the First property.
        /// </summary>
        [TestMethod]
        public void MiddleNameArgumentShouldBindToProperty()
        {
            const string middleName = "Other";

            PersonName personName = new PersonName("Some", middleName, "User");

            Assert.AreEqual(middleName, personName.Middle);
        }

        /// <summary>
        /// Tests that the lastName argument binds to the First property.
        /// </summary>
        [TestMethod]
        public void LastNameArgumentShouldBindToProperty()
        {
            const string lastName = "User";

            PersonName personName = new PersonName("Some", null, lastName);

            Assert.AreEqual(lastName, personName.Last);
        }
    }
}