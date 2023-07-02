using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, ApiResponse<UserModel>>
    {
        private readonly IUsersService usersService;

        public GetUserByUsernameQueryHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<ApiResponse<UserModel>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            return new ApiResponse<UserModel>(await usersService.GetUserByUsernameAsync(request.Username, cancellationToken));
        }
    }
}
