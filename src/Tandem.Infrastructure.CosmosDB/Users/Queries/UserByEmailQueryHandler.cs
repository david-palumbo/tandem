using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.Azure.Cosmos;

using Tandem.Application.Users.Queries;
using Tandem.Application.Users.Views;

namespace Tandem.Infrastructure.CosmosDB.Users.Queries
{
    /// <summary>
    /// Handles the execution of querying Cosmos DB for a user by email.
    /// </summary>
    public class UserByEmailQueryHandler : IRequestHandler<UserByEmailQuery, UserDetailView>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="UserByEmailQueryHandler"/> class.
        /// </summary>
        /// <param name="container">
        /// Required Cosmos DB container.
        /// </param>
        public UserByEmailQueryHandler(Container container)
        {
            this.container = container
                 ?? throw new ArgumentNullException(nameof(container));
        }

        /// <inheritdoc />
        public async Task<UserDetailView> Handle(
            UserByEmailQuery request,
            CancellationToken cancellationToken)
        {
            var sqlQueryText = "SELECT * FROM c WHERE c.EmailAddress = @EmailAddress";


            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText)
                .WithParameter("@EmailAddress", request.EmailAddress);
            

            FeedIterator<UserPersistenceModel> results
                = container.GetItemQueryIterator<UserPersistenceModel>(queryDefinition);

            if (results.HasMoreResults)
            {
                FeedResponse<UserPersistenceModel> page
                    = await results.ReadNextAsync(cancellationToken);

                var user = page.FirstOrDefault();

                if (user != null)
                {
                    return new UserDetailView()
                    {
                        UserId = user.Id,
                        Name = $"{user.FirstName} {user.MiddleName} {user.LastName}",
                        PhoneNumber = user.PhoneNumber,
                        EmailAddress = user.EmailAddress
                    };
                }

            }

            return null;

        }

        private readonly Container container;
    }
}