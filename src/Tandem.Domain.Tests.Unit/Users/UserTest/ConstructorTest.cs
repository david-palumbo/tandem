using System;
using System.Diagnostics.CodeAnalysis;

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
            User user = new User(validPersonName, validPhoneNumber, validEmailAddress);

            Assert.AreNotEqual(Guid.Empty, user.Id);
            Assert.AreEqual(validPersonName, user.Name);
            Assert.AreEqual(validPhoneNumber, user.PhoneNumber);
            Assert.AreEqual(validEmailAddress, user.EmailAddress);
        }

        /// <summary>
        /// Tests that passing a null name argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullNameShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new User(null, validPhoneNumber, validEmailAddress));
            Assert.AreEqual<string>("name", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null phoneNumber argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullPhoneNumberShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new User(validPersonName, null, validEmailAddress));
            Assert.AreEqual<string>("phoneNumber", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null emailAddress argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullEmailAddressShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new User(validPersonName, validPhoneNumber, null));
            Assert.AreEqual<string>("emailAddress", exception.ParamName);
        }

        private readonly PersonName validPersonName = new PersonName("Some", null, "User");

        private readonly PhoneNumber validPhoneNumber = new PhoneNumber("777-888-9999");

        private readonly  EmailAddress validEmailAddress = new EmailAddress("dark-helmet@spaceball.one");
    }
}