using Tandem.Domain.Users;

namespace Tandem.Infrastructure.CosmosDB.Users
{
    /// <summary>
    /// Cosmos DB extensions for user domain objects.
    /// </summary>
    public static class UserExtensions
    {
        /// <summary>
        /// Converts the supplied <paramref name="user"/> to a persistence model.
        /// </summary>
        /// <param name="user">
        /// Required user to convert.
        /// </param>
        internal static UserPersistenceModel ToPersistenceModel(this User user)
        {
            return new UserPersistenceModel()
            {
                Id = user.Id,
                FirstName = user.Name.First,
                MiddleName = user.Name.Middle,
                LastName = user.Name.Last,
                PhoneNumber = user.PhoneNumber.Value,
                EmailAddress = user.EmailAddress.Value
            };
        }
    }
}