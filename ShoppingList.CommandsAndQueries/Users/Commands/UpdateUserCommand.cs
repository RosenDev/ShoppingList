using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class UpdateUserCommand : IRequest<string>
    {
        public UpdateUserModel User { get; set; }
    }
}
