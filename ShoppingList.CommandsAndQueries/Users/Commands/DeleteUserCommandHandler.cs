using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUsersService usersService;

        public DeleteUserCommandHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await usersService.DeleteAsync(request.Id.ToGuid(), cancellationToken);
        }
    }
}
