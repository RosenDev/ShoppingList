using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class CreateUserCommand : IRequest<ApiResponse<string>>
    {
        public CreateUserModel User { get; set; }
    }
}
