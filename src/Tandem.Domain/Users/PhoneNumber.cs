using System;
using System.Text.RegularExpressions;

using Tandem.Kernel;

namespace Tandem.Domain.Users
{
    /// <summary>
    /// Represents a phone number.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PhoneNumber"/> class.
        /// </summary>
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (!Regex.IsMatch(value, "(1-)?\\p{N}{3}-\\p{N}{3}-\\p{N}{4}\\b"))
            {
                throw new ValidationException()
                {
                    UserFriendlyMessage = "Invalid phone number."
                };
            }

            Value = value;
        }

        /// <summary>
        /// Gets the value of the phone number as a string.
        /// </summary>
        public string Value { get; }
    }
}