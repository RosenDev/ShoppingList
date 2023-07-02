using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.CommandsAndQueries.Users.Commands;
using ShoppingList.CommandsAndQueries.Users.Queries;

namespace ShoppingList.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetUserByUsernameQuery
            {
                Username = HttpContext.User.Identity!.Name!
            }));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] CreateUserCommand createUserCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(createUserCommand, ct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserCommand updateUserCommand, CancellationToken ct)
        {
            return Ok(await mediator.Send(updateUserCommand, ct));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id, CancellationToken ct)
        {
            await mediator.Send(new DeleteUserCommand
            {
                Id = id
            }, ct);

            return Ok();
        }
    }
}
