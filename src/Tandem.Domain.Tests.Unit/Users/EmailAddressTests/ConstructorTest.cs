using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Domain.Users;
using Tandem.Kernel;

namespace Tandem.Domain.Tests.Unit.Users.EmailAddressTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="EmailAddress"/> class.
    /// </summary>
    [TestClass]
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null value argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void NullValueShouldThrowException()
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(
                () => new EmailAddress(null));
            Assert.AreEqual<string>("value", exception.ParamName);
        }


        /// <summary>
        /// Tests that supplying an invalid format argument will result in a
        /// <see cref="ValidationException"/> being thrown.
        /// </summary>
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void InvalidFormatShouldThrowException()
        {
            ValidationException exception = Assert.ThrowsException<ValidationException>(
                () => new EmailAddress("I am not an actual email address"));
            Assert.AreEqual<string>("Invalid email address.", exception.UserFriendlyMessage);
        }

        /// <summary>
        /// Tests that a valid email format is bound to the Value property.
        /// </summary>
        [TestMethod]
        public void ValidEmailAddressShouldBindToValue()
        {
            const string format = "dark-helmet@spaceball.one";

            EmailAddress EmailAddress = new EmailAddress(format);

            Assert.AreEqual(format, EmailAddress.Value);
        }
    }
}