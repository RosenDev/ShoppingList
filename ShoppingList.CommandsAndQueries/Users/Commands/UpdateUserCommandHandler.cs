using MediatR;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUsersService usersService;

        public UpdateUserCommandHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await usersService.UpdateAsync(request.User, cancellationToken);
        }
    }
}
