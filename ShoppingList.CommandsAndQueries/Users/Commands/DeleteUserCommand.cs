using MediatR;
using ShoppingList.Common;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class DeleteUserCommand : IRequest<ApiResponse>
    {
        public string Id { get; set; }
    }
}
