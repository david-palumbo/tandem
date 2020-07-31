using System;
using Newtonsoft.Json;

namespace Tandem.Infrastructure.CosmosDB.Users
{
    /// <summary>
    /// Represents the persistent structure of a user.
    /// </summary>
    internal class UserPersistenceModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for this user.
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name for the user.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name for the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number for the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address for the user.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}