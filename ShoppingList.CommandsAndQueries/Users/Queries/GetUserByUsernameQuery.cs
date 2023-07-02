using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Queries
{
    public class GetUserByUsernameQuery : IRequest<ApiResponse<UserModel>>
    {
        public string Username { get; set; }
    }
}
