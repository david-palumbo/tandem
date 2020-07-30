using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Mvc;

using Tandem.Application.Users.Commands;
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

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            throw new NotImplementedException();
        }

        private readonly IMediator mediator;
    }
}