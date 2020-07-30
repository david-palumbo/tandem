using Tandem.Domain.Users;

namespace Tandem.Application.Users.Commands
{
    /// <summary>
    /// Extends the <see cref="CreateUserCommand"/> class to integrate with the
    /// domain objects.
    /// </summary>
    public static class CreateUserCommandDomainExtensions
    {
        /// <summary>
        /// Converts the <paramref name="command"/> to a User entity.
        /// </summary>
        /// <param name="command">
        /// Required command to convert.
        /// </param>
        public static User ToUserEntity(this CreateUserCommand command)
        {
            PersonName name = new PersonName(
                command.FirstName, 
                command.MiddleName, 
                command.LastName);

            PhoneNumber phoneNumber = new PhoneNumber(command.PhoneNumber);
            EmailAddress emailAddress = new EmailAddress(command.EmailAddress);

            return new User(name, phoneNumber, emailAddress);
        }
    }
}