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

        /// <summary>
        /// Tests that searching for a user that does not exists will return a 404.
        /// </summary>
        [TestMethod]
        public async Task SearchForNonExistingUser()
        {
            swaggerClient client = new swaggerClient(baseUrl, httpClient);

            ApiException<ProblemDetails> exception
                = await Assert.ThrowsExceptionAsync<ApiException<ProblemDetails>>(
                    () => client.Users2Async($"{Guid.NewGuid()}@foo.bar"));

            Assert.AreEqual(404, exception.StatusCode);
        }

        /// <summary>
        /// Tests that a 400 response is returned when submitting bad data.
        /// </summary>
        [TestMethod]
        public async Task CreateUserWithBadData()
        {
            swaggerClient client = new swaggerClient(baseUrl, httpClient);

            CreateUserCommand command = new CreateUserCommand()
            {
                FirstName = "Some",
                MiddleName = "Tandem",
                LastName = "User",
                PhoneNumber = "not a phone number",
                EmailAddress = $"{Guid.NewGuid()}@foo.bar"
            };

            ApiException phoneNumberException = await Assert.ThrowsExceptionAsync<ApiException>(
                () => client.UsersAsync(command));

            command.PhoneNumber = "222-333-4444";
            command.EmailAddress = "not an email";

            ApiException emailException = await Assert.ThrowsExceptionAsync<ApiException>(
                () => client.UsersAsync(command));

            Assert.AreEqual(400, phoneNumberException.StatusCode);
            Assert.AreEqual(400, emailException.StatusCode);
        }

        private static HttpClient httpClient = new HttpClient();
        private const string baseUrl = "https://tandemstuff.azurewebsites.net/";
    }
}