using System;

namespace Tandem.Application.Users.Views
{
    /// <summary>
    /// Represents the public view of the details of a user.
    /// </summary>
    public class UserDetailView
    {
        /// <summary>
		/// Gets or sets the unique identifier for the user.
		/// </summary>
		public Guid UserId { get; set; }

        /// <summary>
		/// Gets or sets the name of the user.
		/// </summary>
		public string Name { get; set; }

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