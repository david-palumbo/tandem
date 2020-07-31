using MediatR;
using Tandem.Application.Users.Views;

namespace Tandem.Application.Users.Queries
{
    /// <summary>
    /// Represents the data required for querying a user by an email address.
    /// </summary>
    public class UserByEmailQuery : IRequest<UserDetailView>
    {
        /// <summary>
		/// Gets or sets the email address to filter by.
		/// </summary>
		public string EmailAddress { get; set; }
    }
}