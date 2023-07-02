using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUsersService usersService;

        public CreateUserCommandHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await usersService.AddAsync(request.User, cancellationToken);
        }
    }
}
