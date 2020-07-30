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
        /// <param name="name">
        /// Required name for the user.
        /// </param>
        /// <param name="phoneNumber">
        /// Required phone number for the user.
        /// </param>
        /// <param name="emailAddress">
        /// Required email address for the user.
        /// </param>
        public User(PersonName name, PhoneNumber phoneNumber, EmailAddress emailAddress)
        {
            Name = name 
                ?? throw new ArgumentNullException(nameof(name));
            PhoneNumber = phoneNumber 
                ?? throw new ArgumentNullException(nameof(phoneNumber));
            EmailAddress = emailAddress 
                ?? throw new ArgumentNullException(nameof(emailAddress));
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the unique identifier for this user
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the name for this user.
        /// </summary>
        public PersonName Name { get; }

        /// <summary>
        /// Gets the phone number for this user.
        /// </summary>
        public PhoneNumber PhoneNumber { get; }

        /// <summary>
        /// Gets the email address for this user.
        /// </summary>
        public EmailAddress EmailAddress { get; }
    }
}