using MediatR;
using ShoppingList.Common;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResponse<string>>
    {
        private readonly IUsersService usersService;

        public UpdateUserCommandHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<ApiResponse<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return new ApiResponse<string>(await usersService.UpdateAsync(request.User, cancellationToken));
        }
    }
}
