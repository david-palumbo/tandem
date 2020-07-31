using Microsoft.VisualStudio.TestTools.UnitTesting;

using Tandem.Domain.Users;
using Tandem.Infrastructure.CosmosDB.Users;

namespace Tandem.Infrastructure.CosmosDB.Tests.Unit.Users.UserExtensionsTests
{
    /// <summary>
    /// Unit tests for the ToPersistenceModel method of the <see cref="UserExtensions"/>
    /// class.
    /// </summary>
    [TestClass]
    public class ToPersistenceModelTest
    {
        /// <summary>
        /// Tests that the properties are mapped from the <see cref="User"/> to
        /// the returned <see cref="UserPersistenceModel"/>
        /// </summary>
        [TestMethod]
        public void ShouldMapProperties()
        {
            PersonName name = new PersonName("first", "middle", "last");
            PhoneNumber phoneNumber = new PhoneNumber("444-555-5555");
            EmailAddress emailAddress = new EmailAddress("foo@foo.foo");
            User user = new User(name, phoneNumber, emailAddress);

            UserPersistenceModel model = user.ToPersistenceModel();

            Assert.AreEqual(user.Id, model.Id);
            Assert.AreEqual(user.Name.First, model.FirstName);
            Assert.AreEqual(user.Name.Middle, model.MiddleName);
            Assert.AreEqual(user.Name.Last, model.LastName);
            Assert.AreEqual(user.PhoneNumber.Value, model.PhoneNumber);
            Assert.AreEqual(user.EmailAddress.Value, model.EmailAddress);
        }
    }
}