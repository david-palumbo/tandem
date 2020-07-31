using System;
using System.Threading.Tasks;

using Microsoft.Azure.Cosmos;

using Tandem.Domain.Users;
using User = Tandem.Domain.Users.User;

namespace Tandem.Infrastructure.CosmosDB.Users
{
    /// <summary>
    /// Cosmos DB implementation of the <see cref="IUserRepository"/> interface.
    /// </summary>
    public class CosmosDBUserRepository : IUserRepository
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CosmosDBUserRepository"/> class.
        /// </summary>
        /// <param name="cosmos">
        /// Required Cosmos DB container.
        /// </param>
        public CosmosDBUserRepository(CosmosClient cosmos)
        {
            this.cosmos = cosmos 
                 ?? throw new ArgumentNullException(nameof(cosmos));
        }

        /// <inheritdoc />
        public async Task SaveUserAsync(User user)
        {
            Database database = await cosmos.CreateDatabaseIfNotExistsAsync("SampleDB");
            Container container = await database.CreateContainerIfNotExistsAsync(
                    "Users",
                    "/EmailAddress",
                    400);
            await container.CreateItemAsync(
                user.ToPersistenceModel(),
                new PartitionKey(user.EmailAddress.Value));
        }

        private readonly CosmosClient cosmos;
    }
}