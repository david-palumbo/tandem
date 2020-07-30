using System;
using System.Text.RegularExpressions;

using Tandem.Kernel;

namespace Tandem.Domain.Users
{
    /// <summary>
    /// Represents an email address.
    /// </summary>
    public class EmailAddress
    {
        /// <summary>
        /// Creates a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        /// <param name="value">
        /// Required value for the email.
        /// </param>
        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new ValidationException()
                {
                    UserFriendlyMessage = "Invalid email address."
                };
            }

            Value = value;
        }

        /// <summary>
        /// Gets the value of the email address as a string.
        /// </summary>
        public string Value { get; }
    }
}