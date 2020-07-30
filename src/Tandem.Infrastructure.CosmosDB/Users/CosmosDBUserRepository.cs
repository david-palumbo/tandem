using System.Threading.Tasks;

using Tandem.Domain.Users;

namespace Tandem.Infrastructure.CosmosDB.Users
{
    /// <summary>
    /// Cosmos DB implementation of the <see cref="IUserRepository"/> interface.
    /// </summary>
    public class CosmosDBUserRepository : IUserRepository
    {
        public Task SaveUserAsync(User user)
        {
            return Task.CompletedTask;
        }
    }
}