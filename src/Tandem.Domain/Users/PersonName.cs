using Tandem.Kernel;

namespace Tandem.Domain.Users
{
    /// <summary>
    /// Represents the name of a person.
    /// </summary>
    public class PersonName
    {
        /// <summary>
        /// Creates a new instance of the <see cref="PersonName"/> class.
        /// </summary>
        /// <param name="firstName">
        /// Required firstName name for the person.
        /// </param>
        /// <param name="middleName">
        /// Optional middleName name for the person.
        /// </param>
        /// <param name="lastName">
        /// Required lastName name for the person.
        /// </param>
        public PersonName(string firstName, string middleName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ValidationException()
                {
                    UserFriendlyMessage = "First name is required."
                };
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ValidationException()
                {
                    UserFriendlyMessage = "Last name is required."
                };
            }

            First = firstName;
            Middle = middleName;
            Last = lastName;
        }

        /// <summary>
		/// Gets the firstName name.
		/// </summary>
		public string First { get; }

        /// <summary>
        /// Gets the middleName name.
        /// </summary>
        public string Middle { get; }

        /// <summary>
        /// Gets the lastName name.
        /// </summary>
        public string Last { get; }
    }
}