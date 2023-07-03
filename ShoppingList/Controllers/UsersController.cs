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
        public async Task<IActionResult> RegisterUserAsync(CancellationToken ct)
        {
            var aaaa = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username").Value;
            return Ok(await mediator.Send(new CreateUserCommand
            {
                Username = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "preferred_username").Value
            }, ct));
        }
    }
}
