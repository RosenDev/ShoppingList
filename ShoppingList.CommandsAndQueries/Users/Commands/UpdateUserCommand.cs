using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class UpdateUserCommand : IRequest<ApiResponse<string>>
    {
        public UpdateUserModel User { get; set; }
    }
}
