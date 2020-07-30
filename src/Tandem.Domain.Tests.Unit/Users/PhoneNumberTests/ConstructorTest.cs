using System;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Domain.Users;
using Tandem.Kernel;

namespace Tandem.Domain.Tests.Unit.Users.PhoneNumberTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="PhoneNumber"/> class.
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
                () => new PhoneNumber(null));
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
                () => new PhoneNumber("I am not an actual phone number"));
            Assert.AreEqual<string>("Invalid phone number.", exception.UserFriendlyMessage);
        }

        /// <summary>
        /// Tests that a valid phone number format is bound to the Value property.
        /// </summary>
        [TestMethod]
        public void ValidPhoneNumberShouldBindToValue()
        {
            const string format = "777-888-9999";

            PhoneNumber phoneNumber = new PhoneNumber(format);

            Assert.AreEqual(format, phoneNumber.Value);
        }
    }
}