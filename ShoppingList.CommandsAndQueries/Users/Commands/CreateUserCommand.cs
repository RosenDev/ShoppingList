using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserModel User { get; set; }
    }
}
