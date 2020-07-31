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
        /// <param name="container">
        /// Required Cosmos DB container.
        /// </param>
        public CosmosDBUserRepository(Container container)
        {
            this.container = container 
                 ?? throw new ArgumentNullException(nameof(container));
        }

        /// <inheritdoc />
        public async Task SaveUserAsync(User user)
        {
            
            await container.CreateItemAsync(
                user.ToPersistenceModel(),
                new PartitionKey(user.EmailAddress.Value));
        }

        private readonly Container container;
    }
}