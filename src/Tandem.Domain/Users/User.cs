using System;

namespace Tandem.Domain.Users
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Creates a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the unique identifier for this user
        /// </summary>
        public Guid Id { get; }
    }
}