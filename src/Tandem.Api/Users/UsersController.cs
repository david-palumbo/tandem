using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Tandem.Application.Users.Commands;
using Tandem.Application.Users.Queries;
using Tandem.Application.Users.Views;
using Tandem.Kernel;

namespace Tandem.Api.Users
{
    /// <summary>
    /// Manages the endpoints for user features.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Creates a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mediator">
        /// Required type responsible for mediating commands and queries.
        /// </param>
        public UsersController(IMediator mediator)
        {
            this.mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="command">
        /// Required command containing the data for creating a new user.
        /// </param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            try
            {
                Guid userId = await mediator.Send(command, CancellationToken.None);
                return CreatedAtAction(nameof(Get), userId);
            }
            catch (ValidationException exception)
            {
                return BadRequest(exception.UserFriendlyMessage);
            }
        }
        
        /// <summary>
        /// Gets a user by the supplied <paramref name="email"/>.
        /// </summary>
        /// <param name="email">
        /// Required email address used to find the user
        /// </param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailView>> Get(string email)
        {
            UserByEmailQuery query = new UserByEmailQuery()
            {
                EmailAddress = email
            };

            UserDetailView result = await mediator.Send(query, CancellationToken.None);

            return result ?? (ActionResult<UserDetailView>) NotFound();
        }

        private readonly IMediator mediator;
    }
}