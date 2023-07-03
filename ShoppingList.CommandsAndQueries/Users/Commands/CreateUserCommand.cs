using MediatR;
using ShoppingList.Common;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class CreateUserCommand : IRequest<ApiResponse<string>>
    {
        public string Username { get; set; }
    }
}
