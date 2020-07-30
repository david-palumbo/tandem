using System;

namespace Tandem.Kernel
{
    /// <summary>
    /// Represents a violation of validation rules.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
		/// Gets or sets the message that is safe to display to an end user.
		/// </summary>
		public string UserFriendlyMessage { get; set; }
    }
}