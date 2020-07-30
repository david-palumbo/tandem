using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Tandem.Domain.Users;

namespace Tandem.Application.Users.Commands
{
    /// <summary>
    /// Handles the <see cref="CreateUserCommand"/> command.
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CreateUserCommandHandler"/> class.
        /// </summary>
        /// <param name="userRepository">
        /// Required type responsible for persisting the created user.
        /// </param>
        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository 
                ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <inheritdoc />
        public async Task<Guid> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            User user = request.ToUserEntity();

            await userRepository.SaveUserAsync(user);

            return user.Id;
        }

        private readonly IUserRepository userRepository;
    }
}