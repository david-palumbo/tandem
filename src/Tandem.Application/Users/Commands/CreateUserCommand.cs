using System;

using MediatR;

namespace Tandem.Application.Users.Commands
{
    /// <summary>
    /// Command data for creating a new user.
    /// </summary>
    public class CreateUserCommand : IRequest<Guid>
    {
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