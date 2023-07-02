using MediatR;

namespace ShoppingList.CommandsAndQueries.ProductLists.Commands
{
    public class DeleteProductListCommand : IRequest
    {
        public string Id { get; set; }
    }
}
