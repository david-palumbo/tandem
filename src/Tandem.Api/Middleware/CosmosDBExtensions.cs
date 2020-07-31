using System.Threading.Tasks;

using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace Tandem.Api.Middleware
{
    /// <summary>
    /// Add Cosmos DB to the API middleware.
    /// </summary>
    public static class CosmosDBExtensions
    {
        /// <summary>
        /// Adds Cosmos DB capabilities to the service collection.
        /// </summary>
        /// <param name="serviceCollection">
        /// Required service collection to add Cosmos DB to.
        /// </param>
        /// <param name="endpoint">
        /// Required Cosmos DB endpoint.
        /// </param>
        /// <param name="key">
        /// Required secret key needed to connect to Cosmos DB.
        /// </param>
        public static async Task AddCosmosDBAsync(
            this IServiceCollection serviceCollection,
            string endpoint,
            string key)
        {
            CosmosClient cosmos = new CosmosClient(
                endpoint,
                key,
                new CosmosClientOptions() { ApplicationName = "Tandem" });

            Database database = await cosmos.CreateDatabaseIfNotExistsAsync("SampleDB");
            Container container = await database.CreateContainerIfNotExistsAsync(
                "Users",
                "/EmailAddress",
                400);

            serviceCollection.AddSingleton<Container>(container);
        }
    }
}