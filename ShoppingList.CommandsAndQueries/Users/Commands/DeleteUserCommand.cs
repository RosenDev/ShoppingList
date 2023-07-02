using MediatR;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public string Id { get; set; }
    }
}
