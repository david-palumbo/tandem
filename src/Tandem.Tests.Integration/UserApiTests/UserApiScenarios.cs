using System;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tandem.Tests.Integration.UserApiTests
{
    /// <summary>
    /// Tests the Users API with multiple scenarios.
    /// </summary>
    [TestClass]
    public class UserApiScenarios
    {
        /// <summary>
        /// Tests that a user can be created then found by their email address.
        /// </summary>
        [TestMethod]
        public async Task CreateThenFindUser()
        {
            swaggerClient client = new swaggerClient(baseUrl, httpClient);

            CreateUserCommand command = new CreateUserCommand()
            {
                FirstName = "Some",
                MiddleName = "Tandem",
                LastName = "User",
                PhoneNumber = "111-222-3333",
                EmailAddress = $"{Guid.NewGuid()}@foo.bar"
            };

            await client.UsersAsync(command);

            UserDetailView savedUser = await client.Users2Async(command.EmailAddress);

            string expectedName = $"{command.FirstName} {command.MiddleName} {command.LastName}";

            Assert.AreEqual(expectedName, savedUser.Name);
            Assert.AreEqual(command.EmailAddress, savedUser.EmailAddress);
            Assert.AreEqual(command.EmailAddress, savedUser.EmailAddress);
        }

        private static HttpClient httpClient = new HttpClient();
        private const string baseUrl = "https://tandemstuff.azurewebsites.net/";
    }
}