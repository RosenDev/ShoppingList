using MediatR;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, UserModel>
    {
        private readonly IUsersService usersService;

        public GetUserByUsernameQueryHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<UserModel> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await usersService.GetUserByUsernameAsync(request.Username, cancellationToken);
        }
    }
}
