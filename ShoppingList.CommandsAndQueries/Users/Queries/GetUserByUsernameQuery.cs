using MediatR;
using ShoppingList.Model;

namespace ShoppingList.CommandsAndQueries.Users.Queries
{
    public class GetUserByUsernameQuery : IRequest<UserModel>
    {
        public string Username { get; set; }
    }
}
